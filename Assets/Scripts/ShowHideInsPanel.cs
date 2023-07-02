using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInsPanel : MonoBehaviour
{
    public void ShowInstructionPanel()
    {
        gameObject.SetActive(true);
    }

    public void HideInstructionPanel()
    {
        gameObject.SetActive(false);
    }
}
