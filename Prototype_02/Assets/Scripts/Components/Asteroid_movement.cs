using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Asteroid_movement : MonoBehaviour
{
    //This script is responsible for move the asteroid throw the Bezier curve path.
    //In order for the asteroid to travel over more than one Bézier turn on its route
    //add two "route" gaps to the game scene, connect the endpoint of the first with the 
    //second and so on. Then, specify in the interface the number of routes that the 
    //asteroid will follow and assimilate the necessary "route" objects in the correct 
    //order.
    //To make the asteroid move cyclically, make sure that the last point on the route 
    //is at the same origin as the first.

    //Asteroid own rotation variables
    public float rotationSpeed = 3f;
    public bool clockwise = true;
    private float realRotationSpeed;




    void Start()
    {
        //Asteroid own rotation set minimal randomness  
        realRotationSpeed = (Random.Range(rotationSpeed - 3f, rotationSpeed + 3f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set the speed rotation on the prefab
        float rotAmount;
        //rotate clockwise
        if (clockwise)
        {
            rotAmount = realRotationSpeed * Time.deltaTime;
        }
        else
        //rotate counterclockwise
        {
            rotAmount = realRotationSpeed * -Time.deltaTime;
        }
        //Apply the rotation
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }
}
