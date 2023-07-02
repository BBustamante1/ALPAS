using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class OpenEnterMainHall : MonoBehaviour
{
    private bool disableTouch;
    public static bool canOpenDoor;
    public Transform target;
    public float t;
    public float speed;
    private bool enterHall = false;
    private bool walkHall = false;
    [SerializeField] private GameObject[] mainHallDoor;
    public static GameObject handPointer;
    public GameObject handPointer2;

    private void Awake()
    {
        disableTouch = true;
        canOpenDoor = false;
        handPointer = handPointer2;
        handPointer.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (canOpenDoor)
                {
                    if (hit.transform.tag == "DOOR")
                    {
                        if (disableTouch)
                        {
                            OpenHallDoor();
                            disableTouch = false;
                            enterHall = true;
                            return;
                        }
                        if (enterHall)
                        {
                            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("NPC"))
                            {
                                gameObject.tag = "Finish";
                            }
                            handPointer2.SetActive(false);
                            walkHall = true;
                            enterHall = false;
                            return;
                        }
                    }
                }
            }
        }

        if (walkHall)
        {
            Vector3 cameraPOS = transform.position;
            var targetPOS = new Vector3(target.position.x, target.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(cameraPOS, Vector3.Lerp(cameraPOS, targetPOS, t), speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameObject"))
        {
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Finish"))
            {
                gameObject.tag = "NPC";
                walkHall = false;
            }
        }
    }

    private void OpenHallDoor()
    {
        foreach(GameObject gameObject in mainHallDoor)
        {
            Animator animator;
            animator =  gameObject.GetComponent<Animator>();
            animator.SetTrigger("DoorState");
        }
    }
}