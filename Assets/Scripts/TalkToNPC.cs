using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
 
public class TalkToNPC : MonoBehaviour
{
    public TMP_Text nameText;
    public int currentChapter;
    [Header("NPC Script")]
    [SerializeField] private TextAsset[] npcInkJSON;
    private string npcName;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        Ink.Runtime.Object obj = new Ink.Runtime.IntValue(currentChapter);
        DialougeSystem.GetInstance().SetVariableState("ChapterState", obj);
    }

    void Update()
    {
        Debug.Log("testnpc " + DialougeSystem.GetInstance().dialougeIsPlaying);
        if (!DialougeSystem.GetInstance().dialougeIsPlaying && !DialougeSystem.GetInstance().uiActive)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "NPC")
                    {
                        npcName = hit.transform.name;
                        nameText.text = " ";
                        //interactBTTN.SetActive(true);
                        PlayScript();
                    }
                }
            }
        }
    }

    public void PlayScript()
    {
        foreach (TextAsset textAsset in npcInkJSON)
        {
            if (textAsset.name == npcName)
            {
                DialougeSystem.GetInstance().EnterDialougeMode(textAsset, true);
                break;
            } 
        }
        //Chapter 1
        string[] chap1a1 = { "Ginoo 1", "Ginoo 2", "Binibini 1", "Binibini 2" };
        string[] chap1a2 = { "Ginoo 3", "Binibini 3", "Binibini 4" };
        if (currentChapter == 1)
        {
            foreach (string rnpcName in chap1a1)
            {
                if (rnpcName == npcName)
                {
                    DialougeSystem.GetInstance().EnterDialougeMode(npcInkJSON[7], true);
                    break;
                }
            }
            foreach (string rnpcName in chap1a2)
            {
                if (rnpcName == npcName)
                {
                    DialougeSystem.GetInstance().EnterDialougeMode(npcInkJSON[8], true);
                    break;
                }
            }
        }
        //Chapter 2
        if (currentChapter == 2)
        {
            string[] chap2 = { "Ginoo", "Binibini"};
            foreach(string rnpcName in chap2)
            {
                if(rnpcName == npcName)
                {
                    DialougeSystem.GetInstance().EnterDialougeMode(npcInkJSON[10], true);
                    break;
                }
            }
        }
        //Chapter 3
        if (currentChapter == 3)
        {
            string[] chap3 = { "Ginoo 1", "Ginoo 2", "Binibini 1" };
            foreach (string rnpcName in chap3)
            {
                if (rnpcName == npcName)
                {
                    DialougeSystem.GetInstance().EnterDialougeMode(npcInkJSON[7], true);
                    break;
                }
            }
        }
    }
}