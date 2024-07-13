using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    ZombiePooler pooler;
    [SerializeField] private string name;
    [SerializeField] private float delay;
    private float time;
    [SerializeField] private GameObject[] spawnPoints;

    void Start()
    {
        pooler = ZombiePooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delay)
        {
            pooler.SpawnFromPool(name, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
