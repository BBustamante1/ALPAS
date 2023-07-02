using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterLoader : MonoBehaviour
{
    public int gameSceneNumber;
    private bool targetIsActive;

    private void Awake()
    {
        targetIsActive = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (targetIsActive)
            {
                SceneManager.LoadScene(gameSceneNumber);
            }
        }
    }

    public void FoundTarget()
    {
        targetIsActive = true;
    }
    public void LostTarget()
    {
        targetIsActive = false;
    }
}
