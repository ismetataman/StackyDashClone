using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public StackDecrease stackdecrease;
    public Vector3 offset;
    public Vector3 offsetSecond;
    public Transform target;

    
    void FixedUpdate()
    {
        if(stackdecrease.newCamPos == false)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0,target.position.y + offset.y,target.position.z + offset.z),Time.deltaTime * 2);
        }
        else if(stackdecrease.newCamPos == true)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(4,target.position.y + offsetSecond.y,target.position.z + offsetSecond.z),Time.deltaTime * 2);
        }
    }
}
