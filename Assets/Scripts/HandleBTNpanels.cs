using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBTNpanels : MonoBehaviour
{
    [SerializeField] private GameObject uiBTNS;
    [SerializeField] private GameObject transparentBG;

    public void enterFeature()
    {
        if (!DialougeSystem.GetInstance().dialougeIsPlaying)
        {
            uiBTNS.SetActive(false);
            transparentBG.SetActive(true);
        }
    }

    public void exitFeature()
    {
        uiBTNS.SetActive(true);
        transparentBG.SetActive(false);
    }
}
