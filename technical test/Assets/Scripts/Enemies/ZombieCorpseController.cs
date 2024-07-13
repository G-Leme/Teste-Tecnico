using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieCorpseController : MonoBehaviour
{

    [SerializeField] private GameObject playerPos;

    [SerializeField]private float duration = 0.5f;

    private float elapsedTime;


    void Awake()
    {
      
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
        //Rotates to where the player is looking 
        transform.rotation = Quaternion.LookRotation(playerPos.transform.forward);

        MoveCorpse();
    }

    //Moves the corpse pile towards the player location + Y offset
    private void MoveCorpse()
    {
        elapsedTime = Time.deltaTime;

        //Calculates how long should the pile take to reach the player position
        float percentageComplete = elapsedTime / duration;

        Vector3 currentPos = transform.position;

        Vector3 velocity = Vector3.zero;

        //Moves the corpse pile
        transform.position = Vector3.SmoothDamp(transform.position, playerPos.transform.position, ref velocity, duration);
    }

}
