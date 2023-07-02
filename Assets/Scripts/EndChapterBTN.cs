using System.Collections;
using UnityEngine;

public class EndChapterBTN : MonoBehaviour
{
    [SerializeField]
    private TextAsset endChapterJSON;

    public void ClickedEndBTN()
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        if (!DialougeSystem.GetInstance().dialougeIsPlaying)
        {
            DialougeSystem.GetInstance().EnterDialougeMode(endChapterJSON, false);
        } 
    }
}
