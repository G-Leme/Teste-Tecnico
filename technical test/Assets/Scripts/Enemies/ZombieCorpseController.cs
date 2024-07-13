using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieCorpseController : MonoBehaviour
{

    [SerializeField] private GameObject playerPos;

    [SerializeField]private float duration = 0.5f;

    [SerializeField] private float strength;

    [SerializeField] private float maxAngle = 45f; 

    [SerializeField] private float torqueForce = 10f;

    PlayerController playerController;

    private Rigidbody rb;

    private float elapsedTime;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
      
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void OnEnable()
    {
      
    }

    private void OnDisable()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*
        float currentAngle = Mathf.Abs(transform.localEulerAngles.z);

        
        if (currentAngle < maxAngle || currentAngle > 360f - maxAngle)
        {
            // Apply torque to rotate the object
            rb.AddTorque(playerPos.transform.forward * torqueForce);

        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
        */

        transform.rotation = Quaternion.LookRotation(playerPos.transform.forward);

        ResetCorpsePosition();
    }

    private void MoveCorpse()
    {
     


  
    }

    private void ResetCorpsePosition()
    {
        elapsedTime = Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        Vector3 currentPos = transform.position;

        Vector3 velocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, playerPos.transform.position, ref velocity, duration);
    }
}
