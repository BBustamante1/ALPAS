using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanel : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;

    public void showTutorialPanel()
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        if (!DialougeSystem.GetInstance().dialougeIsPlaying && !DialougeSystem.GetInstance().uiActive)
        {
            DialougeSystem.GetInstance().uiActive = true;
            Time.timeScale = 0;
            tutorialPanel.SetActive(true);
        }
    }

    public void hideTutorialPanel()
    {
        FindObjectOfType<AudioManager>().Play("BackAudio");
        DialougeSystem.GetInstance().uiActive = false;
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }
}
