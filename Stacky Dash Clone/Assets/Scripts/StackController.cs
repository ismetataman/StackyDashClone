using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public Vector3 stackPos;
    void Start()
    {
        stackPos = Vector3.zero;
    }
  
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("stack"))
        {
            stackPos += new Vector3(0,0.9f,0);
            Stacklist.instance.stack.Add(other.gameObject);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.parent = GameObject.Find("Stack").transform;
            other.transform.DOLocalMove(stackPos,0.2f);
            this.gameObject.transform.GetChild(1).transform.localPosition += new Vector3(0,0.9f,0);
            Debug.Log("Listeye eklendi");
        }
    }
}
