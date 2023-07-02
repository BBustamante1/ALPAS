using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstQuestFindKey : MonoBehaviour
{
    [SerializeField] private TMP_Text QuestText;
    [SerializeField] private GameObject firstQuestKey;
    // Start is called before the first frame update
    void Start()
    {
        firstQuestKey.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*string isabelState = ((Ink.Runtime.StringValue)DialougeSystem.GetInstance().GetVariableState("TiyaIsabelState")).value;
        if (isabelState == "2")
        {
            firstQuestKey.SetActive(true);
        }
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Entrance Key")
                {
                    QuestText.text = "Give Key to Tiya Isabel";
                    hit.transform.gameObject.SetActive(false);
                    // convert the variable into a Ink.Runtime.Object value
                    string tiyaIsabelState = "3";
                    Ink.Runtime.Object obj = new Ink.Runtime.StringValue(tiyaIsabelState);
                    // call the DialogueManager to set the variable in the globals dictionary
                    DialougeSystem.GetInstance().SetVariableState("TiyaIsabelState", obj);
                }
            }
        }*/
    }
}


