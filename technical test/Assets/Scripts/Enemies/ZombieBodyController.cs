using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBodyController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject player;
    [SerializeField] private bool enableTorque;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) ;
       // rb.AddTorque(transform.right);

        if(enableTorque == true)
        {
            rb.AddTorque(transform.forward);
        }
    }
}
