using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

class DrawerAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool animationState;
    public GameObject[] drawerList;
    List<Animator> animatorList = new List<Animator>();

    private void Awake()
    {
        animationState = false;
    }

    private void Start()
    {
        if (drawerList.Length >= 1)
        {
            for (int i = 0; i < drawerList.Length; i++)
            {
                animatorList.Add(drawerList[i].GetComponent<Animator>());
                animatorList[i].enabled = false;
            }
        }
        else
        {
            return;
        }
    }
    public void FindDrawer(string drawerName) 
    { 
        if (drawerList.Length >= 1)
        {
            for (int i = 0; i < drawerList.Length; i++)
            {
                if (drawerList[i].name == drawerName)
                {
                    animatorList[i].enabled = true;
                    animatorList[i].SetBool("DrawerState", animationState);        
                }
            }
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Drawer")
                {
                    if(!animationState)
                    {
                        animationState = true;
                    } else
                    {
                        animationState = false;
                    }
                    string drawerName = hit.transform.name;
                    FindDrawer(drawerName);
                }
            }
        }
    }
}