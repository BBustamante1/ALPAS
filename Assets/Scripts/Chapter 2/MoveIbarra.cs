using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class MoveIbarra : MonoBehaviour
{
    public Transform targetObject;
    public float offset;
    public float speed;
    public GameObject tiyago;
    private StartTiyagoMsg variable;

    private void Start()
    {
        variable = tiyago.GetComponent<StartTiyagoMsg>();
    }

    void Update()
    {
        int tiyagoState = ((IntValue)DialougeSystem.GetInstance().GetVariableState("TiyagoState")).value;
        if (variable.checker == 1)
        {
            Vector3 cameraPOS = transform.position;
            Vector3 targetPOS = new Vector3(transform.position.x, transform.position.y, targetObject.position.z + offset);
            transform.position = Vector3.MoveTowards(cameraPOS, targetPOS, speed);
        }
    }

}
