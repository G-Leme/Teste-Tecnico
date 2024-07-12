using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCorpseController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private GameObject playerPos;

    private float elapsedTime;
    [SerializeField]private float duration = 0.5f;

    [SerializeField] private float rotation;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
      
    }

    private void FixedUpdate()
    {/*
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0,0,0);
        Quaternion newRotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime);
        rb.MoveRotation(newRotation);
        */
     
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
       

       elapsedTime = Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        Vector3 currentPos = transform.position;

        transform.position = Vector3.Lerp(currentPos, playerPos.transform.position, percentageComplete);

    }
}
