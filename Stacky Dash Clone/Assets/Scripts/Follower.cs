using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PlayerController playercontroller;
    public PathCreator pathCreator;
    public float speed = 100f;
    float distanceTravelled;

    void Update()
    {
        if(playercontroller.pathCreatorActive == true)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        }
        
    }
}
