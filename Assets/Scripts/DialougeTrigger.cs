using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    public void TalkButtonPressed()
    {
        DialougeSystem.GetInstance().EnterDialougeMode(inkJSON, true);
    }
}
