using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;
    private Vector3 endTouchPosition;
    public bool isMove = false;
    private bool isCollision = false;
    private bool swipeRight =false;
    private bool swipeLeft =false;
    private bool swipeForward =false;
    private bool swipeBack =false;
    private Rigidbody _rb;
    private Animator _anim;

    public LayerMask layer;
    public float swipeRange;
    public float swipeSpeed;
    public bool pathCreatorActive = false;
    public bool pathCreatorSecondActive = false;
    public bool pathCreatorBackActive = false;
    public bool pathCreatorBackSecondActive = false;
    public bool pathCreatorFinish = false;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();
        _anim = this.gameObject.transform.GetChild(1).GetComponent<Animator>();
        isMove = true;
        isCollision = false;
    }

    void Update()
    {
        RaycastHit hit;
        Swipe();
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit,0.55511f,layer))
        {
            isMove = false;
            isCollision = true;
            _anim.SetBool("swim",true);
            Debug.DrawRay(this.transform.position,transform.TransformDirection(Vector3.forward)* hit.distance,Color.green);
        }
        else
        {
            isCollision = false;
            _anim.SetBool("swim",false);
        }
        if(isMove == true)
        {
            if(swipeRight == true)
            {
                transform.position += Vector3.right * swipeSpeed * Time.deltaTime;
            }
            if(swipeLeft == true)
            {
                transform.position += Vector3.left * swipeSpeed * Time.deltaTime;
            }
            if(swipeForward == true)
            {
                transform.position += Vector3.forward * swipeSpeed * Time.deltaTime;
            }
            if(swipeBack == true)
            {
                transform.position += Vector3.back * swipeSpeed * Time.deltaTime;
            }
        }
        
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
            if(isCollision == true)
            {
                if(Distance.x < -swipeRange)
                {
                    isMove = true;
                    transform.rotation = Quaternion.Euler(0,-90,0);
                    swipeLeft = true;
                    swipeRight = false;
                    swipeForward = false;
                    swipeBack = false;
                }
                else if(Distance.x > swipeRange)
                {
                    isMove = true;
                    transform.rotation = Quaternion.Euler(0,90,0);
                    swipeRight = true;
                    swipeLeft = false;
                    swipeBack = false;
                    swipeForward = false;
                }
                else if(Distance.y > swipeRange)
                {
                    isMove = true;
                    transform.rotation = Quaternion.Euler(0,360,0);
                    swipeForward = true;
                    swipeBack = false;
                    swipeLeft = false;
                    swipeRight = false;
                    
                }
                else if(Distance.y < -swipeRange)
                {
                    isMove = true;
                    transform.rotation = Quaternion.Euler(0,-180,0);
                    swipeBack = true;
                    swipeForward = false;
                    swipeLeft = false;
                    swipeRight = false;
                }
            }
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            Vector3 Distance = endTouchPosition - startTouchPosition;
        }
       
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PathCreator"))
        {
            if(swipeForward)
            {
                pathCreatorActive = true;
            }
            if(swipeBack)
            {
                pathCreatorBackActive = false;
            }
        }
        if(other.gameObject.CompareTag("PathCreatorDisactive"))
        {
            if(swipeForward)
            {
                pathCreatorActive = false;
            }
            if(swipeBack)
            {
                pathCreatorBackActive = true;
            }
        } 
        if(other.gameObject.CompareTag("PathCreatorSecond"))
        {
            if(swipeForward)
            {
                pathCreatorSecondActive = true;
            }
            if(swipeBack)
            {
                pathCreatorBackSecondActive = false;
            }
        }
        if(other.gameObject.CompareTag("PathCreatorDisactiveSecond"))
        {
            if(swipeForward)
            {
                pathCreatorSecondActive = false;
            }
            if(swipeBack)
            {
                pathCreatorBackSecondActive = true;
            }
        }
        if(other.gameObject.CompareTag("PathCreatorFinish"))
        {
            if(swipeForward)
            {
                pathCreatorFinish = true;
            }
        }
        if(other.gameObject.CompareTag("Disable"))
        {
            if(swipeForward)
            {
                pathCreatorFinish = false;
                _anim.SetBool("win",true);
            }
        }
    }
}
