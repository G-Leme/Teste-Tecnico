using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;

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
        if(joystick.Horizontal != 0 ||  joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("IsRunning", true);
        }
        else
            animator.SetBool("IsRunning", false);
    }
}
