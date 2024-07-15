using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> zombiePoolDictionary;

    public List<ZombiePool> zombiePools;

    public static ZombiePooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public class ZombiePool
    {
        public string name;

        public GameObject prefab;

        public int size;
    }


    void Start()
    {
        zombiePoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (ZombiePool zombiePool in zombiePools)
        {
            Queue<GameObject> zombiePoolQueue = new Queue<GameObject>();

            for (int i = 0; i < zombiePool.size; i++)
            {
                GameObject zombie = Instantiate(zombiePool.prefab);

                zombie.SetActive(false);

                zombiePoolQueue.Enqueue(zombie);
            }

            zombiePoolDictionary.Add(zombiePool.name, zombiePoolQueue);
        }
    }

   public GameObject SpawnFromPool(string name, Vector3 position, Quaternion rotation)
    {


      GameObject zombieToSpawn =  zombiePoolDictionary[name].Dequeue();

        zombieToSpawn.transform.position = position;

        zombieToSpawn.transform.rotation = rotation;

        zombieToSpawn.SetActive(true);

        zombiePoolDictionary[name].Enqueue(zombieToSpawn);

        return zombieToSpawn;
    }
}
