using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool backBTN;
    public int gameSceneNumber;
    public float transitionTime;
    public GameObject canvasTransition;

    public void clickedButtonUI()
    {
        if (backBTN)
        {
            FindObjectOfType<AudioManager>().Play("BackAudio");
        } 
        else
        {
            FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(gameSceneNumber));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Animator animator = canvasTransition.GetComponent<Animator>();
        animator.SetTrigger("Trigger");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
