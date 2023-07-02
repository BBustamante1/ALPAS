using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class IbarraArrival : MonoBehaviour
{
    public GameObject[] entranceDoor;
    private Animator animator;
    public GameObject removeRaycast;
    public GameObject setRaycast;
    public GameObject endChapterPanel;
    public static bool endChapter = false;
    // Start is called before the first frame update
    void Update()
    {
        int storyState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("StoryState")).value;
        if (storyState == 1)
        {
            removeRaycast.SetActive(false);
            setRaycast.SetActive(true);
            for (int i = 0; i < entranceDoor.Length; i++)
            {
                animator = entranceDoor[i].GetComponent<Animator>();
                animator.SetTrigger("DoorState");
            }
        }
    }
}
