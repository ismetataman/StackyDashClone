using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PlayerController playercontroller;
    public PathCreator pathCreator;
    public PathCreator pathCreatorSecond;
    public float speed = 100f;
    float distanceTravelled;
    float distanceTravelledSecond;

    void Update()
    {
        if(playercontroller.pathCreatorActive == true)
        {
            distanceTravelled += speed * Time.deltaTime *3;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        }
        if(playercontroller.pathCreatorBackActive == true)
        {
            distanceTravelled -= speed * Time.deltaTime *3;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        }
         if(playercontroller.pathCreatorSecondActive == true)
        {
            distanceTravelledSecond += speed * Time.deltaTime *5;
            transform.position = pathCreatorSecond.path.GetPointAtDistance(distanceTravelledSecond);
        }
        if(playercontroller.pathCreatorBackSecondActive == true)
        {
            distanceTravelledSecond -= speed * Time.deltaTime *5;
            transform.position = pathCreatorSecond.path.GetPointAtDistance(distanceTravelledSecond);
        }
        
    }

}
