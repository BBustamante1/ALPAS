using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuizBTN : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    [SerializeField] private GameObject mainMenu, gamePanel;
    [SerializeField] private int indexQuizList;
    [SerializeField] private string category;

    public void CategoryBtn()
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        quizManager.StartGame(indexQuizList, category); //start the game
        mainMenu.SetActive(false);              //deactivate mainMenu
        gamePanel.SetActive(true);              //activate game panel
    }
}
