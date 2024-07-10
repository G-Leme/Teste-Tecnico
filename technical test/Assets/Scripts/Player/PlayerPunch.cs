using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZombieController>() != null) 
        {

            collision.gameObject.GetComponent<ZombieController>().punchedByPlayer = true;
            Debug.Log("I hit a zombie");
        }
    }
}
