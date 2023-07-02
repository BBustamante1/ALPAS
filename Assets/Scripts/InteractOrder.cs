using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InteractOrder : MonoBehaviour
{
    [SerializeField] private GameObject[] exclamationMarks;
    [SerializeField] private int chapterIndex;
    private static InteractOrder instance;
    private bool checker = true;
    
    private void Start()
    {
        instance = this;
    }

    public static InteractOrder GetInstance()
    {
        return instance;
    }

    public void setExclamationMark()
    {
        int isabelState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TiyaIsabelState")).value;
        int tenyenteState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TenyenteState")).value;
        int damasoState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("DamasoState")).value;
        int storyState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("StoryState")).value;
        int tiyagoState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TiyagoState")).value;
        int kasambahayState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("KasambahayState")).value;
        int larujaState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("LarujaState")).value;
        int talkDamasoState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("talkToDamaso")).value;
        int talkTenyenteState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("talkToTenyente")).value;
        int showEndSign = ((IntValue)DialougeSystem.GetInstance().GetVariableState("showEndSign")).value;
        switch (chapterIndex)
        {
            // --- Chapter 1 ---
            case 1:
                if (isabelState >= 2)
                {
                    DestroyExclamationMark(nameof(isabelState));
                }
                if (damasoState >= 1)
                {
                    DestroyExclamationMark(nameof(damasoState));
                }
                if (tenyenteState == 1 && storyState == 0)
                {
                    Debug.Log("testerino");
                    ShowExclamationMark(nameof(tenyenteState));
                }
                if (storyState == 1)
                {
                    ShowExclamationMark("IbarraTiyagoExclamation");
                    DestroyExclamationMark(nameof(tenyenteState));
                }
                if (storyState == 2)
                {
                    DestroyExclamationMark("IbarraTiyagoExclamation");
                }
                break;
            // --- Chapter 2 ---
            case 2:
                if (tiyagoState == 1 && checker)
                {
                    DestroyExclamationMark(nameof(tiyagoState));
                    checker = false;
                }
                if (tiyagoState == 2 && talkDamasoState == 0 && talkTenyenteState == 0)
                {
                    DestroyExclamationMark("BarrierC2");
                    DestroyExclamationMark(nameof(tiyagoState));
                    ShowExclamationMark(nameof(tenyenteState));
                    ShowExclamationMark(nameof(damasoState));
                }
                if (talkDamasoState == 1) DestroyExclamationMark(nameof(damasoState));
                if (talkTenyenteState == 1) DestroyExclamationMark(nameof(tenyenteState));
                if (talkTenyenteState == 1 && talkDamasoState == 1)
                {
                    ShowExclamationMark(nameof(kasambahayState));
                }
                if (kasambahayState == 1) DestroyExclamationMark(nameof(kasambahayState));
                break;
            // --- Chapter 3 --- 
            case 3:
                if (damasoState == 1)
                {
                    ShowExclamationMark(nameof(damasoState));
                    DestroyExclamationMark(nameof(tiyagoState));
                }
                if (larujaState == 1)
                {
                    ShowExclamationMark(nameof(larujaState));
                    DestroyExclamationMark(nameof(damasoState));
                }
                if (damasoState == 2)
                {
                    ShowExclamationMark(nameof(damasoState));
                    DestroyExclamationMark(nameof(larujaState));
                }
                if (showEndSign == 1) DestroyExclamationMark(nameof(damasoState));
                break;
            default:
                Debug.Log("index out of reach");
                break;
        }
    }

    private void DestroyExclamationMark(string stateName)
    {
        foreach (GameObject gameObject in exclamationMarks)
        {
            if (stateName == gameObject.name)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void ShowExclamationMark(string stateName)
    {
        foreach (GameObject gameObject in exclamationMarks)
        {
            if (stateName == gameObject.name)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
