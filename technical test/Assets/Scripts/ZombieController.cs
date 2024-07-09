using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private float timeToTurn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateZombie();
    }

    private void RotateZombie()
    {
        currentTime += Time.deltaTime;

        if (currentTime > timeToTurn)
        {
            currentTime = 0;
            transform.Rotate(0, 180, 0);
        }
    }

}
