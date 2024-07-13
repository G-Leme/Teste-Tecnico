using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float movementSpeed;

    public Rigidbody rb;

    private Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       MovePlayer();
    }

    private void MovePlayer()
    {

        //Moves the player using Physics
        rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y, joystick.Vertical * movementSpeed);

        //Rotates the player
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("IsRunning", true);
     
        }
        else
        {
            animator.SetBool("IsRunning", false);
           
        }
    }

    //Detects if a zombie is in range & throws a punch
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZombieController>() != null)
        {
            collision.gameObject.GetComponent<ZombieController>().punchedByPlayer = true;

            animator.SetTrigger("PunchingRange");

        }
    }

    
}
