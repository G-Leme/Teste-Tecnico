using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float smoothTime;
    
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (target != null)
        {
            //Gets the player position
            Vector3 targetPosition = target.position;

            //Follows player current position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}