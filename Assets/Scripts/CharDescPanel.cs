using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharDescPanel : MonoBehaviour
{
    [SerializeField] private GameObject descPanel;
    [SerializeField] private TMP_Text charDescTMP, charNameTMP;
    private static CharDescPanel instance;

    private void Start()
    {
        instance = this;
    }

    public static CharDescPanel GetInstance()
    {
        return instance;
    }

    public void ShowCharDescription(string characterName, string characterDesc)
    {
        FindObjectOfType<AudioManager>().Play("ConfirmAudio");
        descPanel.SetActive(true);
        charNameTMP.text = characterName;
        charDescTMP.text = characterDesc;
    }

    public void HideCharDescription()
    {
        FindObjectOfType<AudioManager>().Play("BackAudio");
        descPanel.SetActive(false);
    }

    /*void()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "NPC")
                {
                
                }
            }
        }
    }*/
}
