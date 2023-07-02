using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class SpawnTinola : MonoBehaviour
{
    [SerializeField] private GameObject prefabTinola;
    void Update()
    {
        int storyState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("StoryState")).value;
        if (storyState == 1)
        {
            prefabTinola.SetActive(true);
        }
    }
}
