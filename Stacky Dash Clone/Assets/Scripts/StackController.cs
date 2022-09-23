using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackController : MonoBehaviour
{
    public UIManager uimanager;
    public Vector3 stackPos;
    private AudioSource audioSource;
    public AudioClip collectClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stackPos = Vector3.zero;
    }
  
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("stack"))
        {
            audioSource.PlayOneShot(collectClip,1f);
            stackPos += new Vector3(0,0.9f,0);
            Stacklist.instance.stack.Add(other.gameObject);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.parent = GameObject.Find("Stack").transform;
            other.transform.DOLocalMove(stackPos,0f);
            this.gameObject.transform.GetChild(1).transform.localPosition += new Vector3(0,0.9f,0);
            Debug.Log("Listeye eklendi");

            //ScoreIncrease
            uimanager.ScoreIncrease();
        }
        if(other.gameObject.CompareTag("ColorScore"))
        {
            uimanager.ScoreIncrease();
        }
    }
}
