using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class MoveGuevarra : MonoBehaviour
{
    public Transform targetObject;
    public float speed;
    void Update()
    {
        //attached to guevarra
        int damasoState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("DamasoState")).value;
        if (damasoState == 1)
        {
            Vector3 cameraPOS = transform.position;
            Vector3 targetPOS = new Vector3(targetObject.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(cameraPOS, targetPOS, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        DialougeSystem.GetInstance().SetVariableState("TenyenteState", new Ink.Runtime.IntValue(1));
        InteractOrder.GetInstance().setExclamationMark();
    }
}
