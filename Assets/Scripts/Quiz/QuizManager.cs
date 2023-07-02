using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
#pragma warning disable 649
    //ref to the QuizGameUI script
    [SerializeField] private GameObject quitQuizPanel;
    [SerializeField] private TMP_Text categoryText, endScore, questionText, commendText, categoryTextGame;
    [SerializeField] private QuizGameUI quizGameUI;
    //ref to the scriptableobject file
    [SerializeField] private List<QuizDataScriptable> quizDataList;
    [SerializeField] private float timeInSeconds;
#pragma warning restore 649
    private int numOfQuestions;
    private string currentCategory = "";
    private int correctAnswerCount = 0;
    private bool pauseTimer = false;
    //questions data
    private List<Question> questions;
    //current question data
    private Question selectedQuetion = new Question();
    private int gameScore;
    private float currentTime;
    private QuizDataScriptable dataScriptable;

    private GameStatus gameStatus = GameStatus.NEXT;

    public GameStatus GameStatus { get { return gameStatus; } }

    public List<QuizDataScriptable> QuizData { get => quizDataList; }

    public void StartGame(int categoryIndex, string category)
    {
        quitQuizPanel.SetActive(false);
        categoryTextGame.text = category;
        questionText.text = "Question " + numOfQuestions.ToString() + "/10";
        currentCategory = category;
        correctAnswerCount = 0;
        gameScore = 0;
        currentTime = timeInSeconds;
        //set the questions data
        questions = new List<Question>();
        dataScriptable = quizDataList[categoryIndex];
        questions.AddRange(dataScriptable.questions);
        //select the question
        SelectQuestion();
        gameStatus = GameStatus.PLAYING;
    }

    /// <summary>
    /// Method used to randomly select the question form questions data
    /// </summary>
    private void SelectQuestion()
    {
        numOfQuestions = numOfQuestions + 1;
        questionText.text = "Question " + numOfQuestions.ToString() + "/10";
        //get the random number
        int val = UnityEngine.Random.Range(0, questions.Count);
        //set the selectedQuetion
        selectedQuetion = questions[val];
        //send the question to quizGameUI
        quizGameUI.SetQuestion(selectedQuetion);

        questions.RemoveAt(val);
    }

    private void Update()
    {
        if (gameStatus == GameStatus.PLAYING)
        {
            if (!pauseTimer)
            {
                currentTime -= Time.deltaTime;
                SetTime(currentTime);
            }
        }
    }

    void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);                       //set the time value
        quizGameUI.TimerText.text = time.ToString("mm':'ss");   //convert time to Time format

        if (currentTime <= 0)
        {
            //Game Over
            GameEnd();
        }
    }

    /// <summary>
    /// Method called to check the answer is correct or not
    /// </summary>
    /// <param name="selectedOption">answer string</param>
    /// <returns></returns>
    public bool Answer(string selectedOption)
    {
        //set default to false
        bool correct = false;
        //if selected answer is similar to the correctAns
        if (selectedQuetion.correctAns == selectedOption)
        {
            //Yes, Ans is correct
            correctAnswerCount++;
            correct = true;
            gameScore += 50;
            quizGameUI.ScoreText.text = "Score:" + gameScore;
        }
        else
        {
            quizGameUI.ShowCorrectAnswer(selectedQuetion.correctAns);
            //No, Ans is wrong
            //Reduce Life
        }
        pauseTimer = true;
        //return the value of correct bool
        return correct;
    }

    public void NextQuestion()
    {
        if (gameStatus == GameStatus.PLAYING)
        {
            if (questions.Count > 0)
            {
                FindObjectOfType<AudioManager>().Play("ConfirmAudio");
                currentTime = timeInSeconds;
                //call SelectQuestion method again after 1s
                Invoke("SelectQuestion", 0.0f);
            }
            else
            {
                GameEnd();
            }
            pauseTimer = false;
        }
    }

    public void ShowQuitQuizPanel()
    {
        FindObjectOfType<AudioManager>().Play("BackAudio");
        quitQuizPanel.SetActive(true);
    }

    public void HideQuitQuizPanel()
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        quitQuizPanel.SetActive(false);
    }

    public void GameEnd()
    {
        gameStatus = GameStatus.NEXT;
        quizGameUI.GameOverPanel.SetActive(true);

        //fi you want to save only the highest score then compare the current score with saved score and if more save the new score
        //eg:- if correctAnswerCount > PlayerPrefs.GetInt(currentCategory) then call below line

        //Save the score
        PlayerPrefs.SetInt(currentCategory, correctAnswerCount); //save the score for this category
        categoryText.text = currentCategory;
        endScore.text = correctAnswerCount.ToString()+"/10";
        if (correctAnswerCount > 7)
        {
            commendText.text = "Mahusay!";
        }
        else
        {
            commendText.text = "";
        }
    }
}

//Datastructure for storeing the quetions data
[System.Serializable]
public class Question
{
    public string questionInfo;         //question text
    public QuestionType questionType;   //type
    public Sprite questionImage;        //image for Image Type
    public AudioClip audioClip;         //audio for audio type
    public UnityEngine.Video.VideoClip videoClip;   //video for video type
    public List<string> options;        //options to select
    public string correctAns;           //correct option
    public string triva;
}

[System.Serializable]
public enum QuestionType
{
    TEXT,
    IMAGE,
    AUDIO,
    VIDEO
}

[SerializeField]
public enum GameStatus
{
    PLAYING,
    NEXT
}