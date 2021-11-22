using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public float rotationalInterpolation;
    public Vector3 velocity;
    Vector3 lastVelocity;

    private void LateUpdate()
    {
        
        Vector3 angle = velocity.normalized;
        //Quaternion angle = Quaternion.Euler(velocity);
        Quaternion nextRotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(angle * Time.deltaTime), 5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, rotationalInterpolation);
        //transform.rotation = Quaternion.Slerp(transform.rotation, angle, 0.85f);
        //transform.rotation = angle;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(angle), 0.35f);


        //transform.position += Vector3.Lerp(transform.forward * lastVelocity.magnitude, transform.forward * velocity.magnitude * Time.deltaTime, 0.5f);
        transform.position += transform.forward * velocity.magnitude * Time.deltaTime;
        //transform.Translate(Vector3.Lerp(Vector3.zero, velocity * Time.deltaTime, 0.95f));
        lastVelocity = velocity;
    }
}
