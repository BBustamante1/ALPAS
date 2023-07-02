using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAtPlayer : MonoBehaviour
{
    public Transform cameraObject;

    void Update()
    {

        transform.LookAt(new Vector3(cameraObject.position.x, cameraObject.position.y, cameraObject.position.z));
    }
}
