using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class ChapterIndex : MonoBehaviour
{
    [SerializeField] private int indexScene;
    [SerializeField] private string chapterName;

    public void setChapIndex()
    {
        StartCoroutine(LoadScene.GetInstance().EnterDialougeMode(indexScene, chapterName));
    }
}
