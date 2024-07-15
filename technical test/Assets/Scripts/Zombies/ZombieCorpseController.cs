using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieCorpseController : MonoBehaviour
{

    [SerializeField] private GameObject playerPos;

    [SerializeField]private float duration = 0.5f;

    ZombieCorpseSpawner corpseDuration;

    void Awake()
    {
        corpseDuration = FindAnyObjectByType<ZombieCorpseSpawner>();
        playerPos = GameObject.Find("PlayerPos");
       // Debug.Log(corpseOffset.offset);
        
    }

    private void OnEnable()
    {
        duration += corpseDuration.duration;
    }

    private void OnDisable()
    {
        duration = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotates to where the player is looking 
        transform.rotation = Quaternion.LookRotation(playerPos.transform.forward);

        MoveCorpse();
    }

    //Moves the corpse pile towards the player location
    private void MoveCorpse()
    {
        Vector3 target = new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z);

        Vector3 currentTransform = transform.position;

        Vector3 velocity = Vector3.zero;

        //Moves the corpse pile
        transform.position = Vector3.SmoothDamp(currentTransform, target,ref velocity, duration);
    }

}
