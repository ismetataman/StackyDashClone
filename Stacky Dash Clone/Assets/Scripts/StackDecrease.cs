using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDecrease : MonoBehaviour
{
    public StackController stackcontroller;
    public bool newCamPos = false;
    public Material otherColor;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("UnStack"))
        {
            newCamPos = true;
            stackcontroller.stackPos -= new Vector3(0,0.9f,0);
            Destroy(Stacklist.instance.stack[Stacklist.instance.stack.Count-1]);
            Stacklist.instance.stack.RemoveAt(Stacklist.instance.stack.Count -1);
            this.gameObject.transform.GetChild(1).transform.localPosition -= new Vector3(0,0.9f,0);
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        if(other.gameObject.CompareTag("PathCreatorDisactiveSecond"))
        {
            //To move camera first position
            newCamPos = false;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("UnStack"))
        {
            other.gameObject.transform.GetComponent<MeshRenderer>().material = otherColor;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }   
    }
    
}
