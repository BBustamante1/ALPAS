using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StartTiyagoMsg : MonoBehaviour
{
    [Header("Kapitan Tiyago Script")]
    public GameObject tiyagoState;
    public Transform targetObject;
    public Transform targetObject2;
    public float offset;
    public float speed;
    public int checker = 0;
    private bool setTag = true;
    public static StartTiyagoMsg instance;


    private void Start()
    {
        instance = this;
    }

    public static StartTiyagoMsg GetInstance()
    {
        return instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameObject")
        {
            setTag = false;
            gameObject.tag = "NPC";
            tiyagoState.SetActive(true);
        }
    }

    public void StartMovement()
    {
        int tiyagoStatenum = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TiyagoState")).value;
        if (tiyagoStatenum == 1) checker = 1;
        if (tiyagoStatenum == 2) checker = 2;
    }

    void Update()
    {
        Vector3 cameraPOS = transform.position;
        if (checker == 1)
        {
            if (setTag) gameObject.tag = "Untagged";
            Vector3 targetPOS = new Vector3(transform.position.x, transform.position.y, targetObject.position.z + offset);
            transform.position = Vector3.MoveTowards(cameraPOS, targetPOS, speed);
        }
        if (checker == 2)
        {
            Vector3 targetPOS = new Vector3(targetObject2.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(cameraPOS, targetPOS, speed);
        }
    }
}
