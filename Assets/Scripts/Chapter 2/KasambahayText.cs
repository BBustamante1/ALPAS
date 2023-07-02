using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class KasambahayText : MonoBehaviour
{
    [Header("Kasambahay Script")]
    [SerializeField] private TextAsset kasambahayInkJSON;
    private bool checkerBool = true;
    void Update()
    {
        int TalkDamaso = ((IntValue)DialougeSystem.GetInstance().GetVariableState("talkToDamaso")).value;
        int TalkTenyente = ((IntValue)DialougeSystem.GetInstance().GetVariableState("talkToTenyente")).value;
        if (TalkDamaso > 0 && TalkTenyente > 0 && checkerBool)
        {
            checkerBool = false;
            DialougeSystem.GetInstance().EnterDialougeMode(kasambahayInkJSON, true);
        }
    }
}
