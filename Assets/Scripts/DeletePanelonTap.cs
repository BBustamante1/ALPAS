using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePanelonTap : MonoBehaviour
{
    public GameObject bgTrans;
    public GameObject introPanel;

    public void SetFalse()
    {
        if (DialougeSystem.GetInstance().uiActive)
        {
            FindObjectOfType<AudioManager>().Play("ConfirmAudio");
            gameObject.SetActive(false);
            bgTrans.SetActive(false);
            introPanel.SetActive(false);
            DialougeSystem.GetInstance().dialougeIsPlaying = false;
            DialougeSystem.GetInstance().showQuestPanel = true;
            DialougeSystem.GetInstance().uiActive = false;
        }
    }
}
