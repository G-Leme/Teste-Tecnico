using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieCorpseController : MonoBehaviour
{

    [SerializeField] private GameObject playerPos;

    [SerializeField]private float duration = 0.5f;

    private float elapsedTime;


    ZombieCorpseSpawner corpseOffset;

    void Awake()
    {
        corpseOffset = FindAnyObjectByType<ZombieCorpseSpawner>();
        playerPos = GameObject.Find("PlayerPos");
       // Debug.Log(corpseOffset.offset);
        
    }

    private void OnEnable()
    {
       // transform.position = new Vector3(0, transform.position.y + corpseOffset.offset, 0);
        duration += corpseOffset.delay;
    }

    private void OnDisable()
    {
      
    }
    private void Start()
    {
     //   transform.position = new Vector3(0, transform.position.y + corpseOffset.offset, 0);

        // transform.position = positionWithOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotates to where the player is looking 
        transform.rotation = Quaternion.LookRotation(playerPos.transform.forward);

        MoveCorpse();
    }

    //Moves the corpse pile towards the player location + offset
    private void MoveCorpse()
    {
        Vector3 target = new Vector3(playerPos.transform.position.x, transform.position.y, playerPos.transform.position.z);

        Vector3 currentTransform = transform.position;

        Vector3 velocity = Vector3.zero;

        //Moves the corpse pile
        transform.position = Vector3.SmoothDamp(currentTransform, target,ref velocity, duration);
    }

}
