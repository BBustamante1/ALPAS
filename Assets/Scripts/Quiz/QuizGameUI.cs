using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizGameUI : MonoBehaviour
{
#pragma warning disable 649

    [SerializeField] private QuizManager quizManager;               //ref to the QuizManager script
    [SerializeField] private TMP_Text scoreText, timerText, triviaText, triviaTitle;
    [SerializeField] private GameObject gameOverPanel, mainMenu, gamePanel, triviaPanel, nextBTN, quitBTN;
    [SerializeField] private Color correctCol, wrongCol, normalCol; //color of buttons
    [SerializeField] private TMP_Text questionInfoText;                 //text to show question
    [SerializeField] private List<Button> options;                  //options button reference
#pragma warning restore 649

    private float audioLength;          //store audio length
    private Question question;          //store current question data
    private bool answered = false;      //bool to keep track if answered or not

    public TMP_Text TimerText { get => timerText; }                     //getter
    public TMP_Text ScoreText { get => scoreText; }                     //getter
    public GameObject GameOverPanel { get => gameOverPanel; }                     //getter

    private void Start()
    {
        //add the listner to all the buttons
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
    }
    /// <summary>
    /// Method which populate the question on the screen
    /// </summary>
    /// <param name="question"></param>
    public void SetQuestion(Question question)
    {
        nextBTN.SetActive(false);
        quitBTN.SetActive(true);
        triviaPanel.SetActive(false);
        //set the question
        this.question = question;
        //check for questionType
        questionInfoText.text = question.questionInfo;                      //set the question text

        //suffle the list of options
        List<string> ansOptions = ShuffleList.ShuffleListItems<string>(question.options);

        //assign options to respective option buttons
        for (int i = 0; i < options.Count; i++)
        {
            //set the child text
            options[i].GetComponentInChildren<TMP_Text>().text = ansOptions[i];
            options[i].name = ansOptions[i];    //set the name of button
            options[i].image.color = normalCol; //set color of button to normal
        }

        answered = false;                       

    }


    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (question.questionType == QuestionType.AUDIO)
        {
            //wait for few seconds
            yield return new WaitForSeconds(audioLength + 0.5f);
            //play again
            StartCoroutine(PlayAudio());
        }
        else //if questionType is not audio
        {
            //stop the Coroutine
            StopCoroutine(PlayAudio());
            //return null
            yield return null;
        }
    }

    /// <summary>
    /// Method assigned to the buttons
    /// </summary>
    /// <param name="btn">ref to the button object</param>
    void OnClick(Button btn)
    {
        if (quizManager.GameStatus == GameStatus.PLAYING)
        {
            //if answered is false
            if (!answered)
            {
                //set answered true
                answered = true;
                //get the bool value
                bool val = quizManager.Answer(btn.name);

                //if its true
                if (val)
                {
                    //set color to correct
                    //btn.image.color = correctCol;
                    FindObjectOfType<AudioManager>().Play("Correct Answer");
                    StartCoroutine(BlinkImg(btn.image));
                }
                else
                {
                    //else set it to wrong color
                    FindObjectOfType<AudioManager>().Play("Wrong Answer");
                    btn.image.color = wrongCol;
                    nextBTN.SetActive(true);
                    quitBTN.SetActive(false);
                }
            }
        }
    }

    public void ShowCorrectAnswer(string correctAnswerBTN)
    {
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].name == correctAnswerBTN)
            {
                options[i].image.color = correctCol;
                break;
            }
        }
    }

    //Method called by Category Button
    private void CategoryBtn(int index, string category)
    {
        quizManager.StartGame(index, category); //start the game
        mainMenu.SetActive(false);              //deactivate mainMenu
        gamePanel.SetActive(true);              //activate game panel
    }

    //this give blink effect [if needed use or dont use]
    IEnumerator BlinkImg(Image img)
    {
        for (int i = 0; i < 2; i++)
        {
            img.color = Color.white;
            yield return new WaitForSeconds(0.15f);
            img.color = correctCol;
            yield return new WaitForSeconds(0.15f);
        }
        triviaPanel.SetActive(true);
        //trivia text
        triviaText.text = question.triva;
        triviaTitle.text = "Trivia";
        nextBTN.SetActive(true);
        quitBTN.SetActive(false);
    }

    public void RestryButton()
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
