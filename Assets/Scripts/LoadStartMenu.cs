using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadStartMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public float transitionTime;
    public int indexScene;

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        //yield return new WaitForSeconds(transitionTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            yield return null;
        }
    }

    private void Awake()
    {
        StartCoroutine(LoadSceneAsync(indexScene));
    }
}
