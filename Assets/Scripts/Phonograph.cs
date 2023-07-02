using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    void Update()
    {
        if (!DialougeSystem.GetInstance().dialougeIsPlaying)
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Phonograph")
                    {
                        SoundManager.Instance.PlaySound(clip);
                    }
                }
            }
        }
    }
}
