using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    void Update()
    {
        Swipe();
    }
    public void Swipe()
    {
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector3 Distance = currentPosition - startTouchPosition;

            if(!stopTouch)
            {
                if(Distance.x < -swipeRange)
                {
                    this.gameObject.transform.Translate(Vector3.left *5);
                    Debug.Log("Left");
                    stopTouch = true;
                }
                else if(Distance.x > swipeRange)
                {
                    this.gameObject.transform.Translate(Vector3.right *5);
                    Debug.Log("Right");
                    stopTouch = true;
                }
                else if(Distance.y > swipeRange)
                {
                    this.gameObject.transform.Translate(Vector3.forward *5);
                    Debug.Log("Up");
                    stopTouch = true;
                }
                 else if(Distance.y < -swipeRange)
                {
                    this.gameObject.transform.Translate(Vector3.back *5);
                    Debug.Log("Down");
                    stopTouch = true;
                }
            }
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector3 Distance = endTouchPosition - startTouchPosition;
        }
       
    }
}
