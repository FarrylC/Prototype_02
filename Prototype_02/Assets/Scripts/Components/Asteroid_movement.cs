using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_movement : MonoBehaviour
{
    public float rotationSpeed = 3f;
    public bool clockwise = true;
    private float realRotationSpeed;


     void Start()
    {
        realRotationSpeed = (Random.Range(rotationSpeed - 3f, rotationSpeed + 3f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotAmount;
        if (clockwise)
        { 
            rotAmount = realRotationSpeed * Time.deltaTime; 
        }
        else
        {
            rotAmount = realRotationSpeed * -Time.deltaTime;
        }

        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }
}
