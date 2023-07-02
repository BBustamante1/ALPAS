using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExamineQuest : MonoBehaviour
{
    public GameObject questPanel;
    public GameObject questToggle;
    public GameObject examineArea;
    public GameObject[] examineQuest;
    public Toggle[] toggleQuest;
    private TMP_Text questText;
    public static bool startQuest = false;
    [SerializeField] private TextAsset examineStartJSON;
    [SerializeField] private TextAsset examineQuestJSON;
    public static int toggleCompleted = 0;

    private void Awake()
    {
        questPanel.SetActive(false);
        questToggle.SetActive(false);
        examineArea.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TargetMovement")
        {
            Debug.Log("test");
            //StartCoroutine(DialougeSystem.GetInstance().EnterDialougeMode(examineStartJSON, true));
            startQuest = true;
        }
    }

    public void StartExamineQuest ()
    {
        questPanel.SetActive(true);
        questToggle.SetActive(true);
        examineArea.SetActive(true);
        questText.text = "Examine Hall";
    }

    IEnumerator EndExamineQuest()
    {
        yield return new WaitForSeconds(1);
        startQuest = false;
        questPanel.SetActive(false);
        questToggle.SetActive(false);
        examineArea.SetActive(false);
    }

    private void Update()
    {
        if (toggleCompleted == 3)
        {
            StartCoroutine(EndExamineQuest());
        }
        if (startQuest && !DialougeSystem.GetInstance().dialougeIsPlaying)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "ExamineArea")
                    {
                        string areaName = hit.transform.name;
                        for (int i = 0; i < examineQuest.Length ;i++)
                        {
                            if (areaName == examineQuest[i].name)
                            {
                                int questState = i;
                                Ink.Runtime.Object obj = new Ink.Runtime.IntValue(questState);
                                // call the DialogueManager to set the variable in the globals dictionary
                                DialougeSystem.GetInstance().SetVariableState("ExamineQuest", obj);
                                //StartCoroutine(DialougeSystem.GetInstance().EnterDialougeMode(examineQuestJSON, true));
                                examineQuest[i].SetActive(false);
                                for (int a = 0; a <toggleQuest.Length; a++)
                                {
                                    if (examineQuest[i].name == toggleQuest[a].name)
                                    {
                                        toggleQuest[a].isOn = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
