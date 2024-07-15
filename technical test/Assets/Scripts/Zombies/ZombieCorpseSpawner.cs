using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieCorpseSpawner : MonoBehaviour
{
    
    [SerializeField] private string id;

    [SerializeField] private GameObject player;

    [HideInInspector] public bool spawnedCorpse;

    [HideInInspector] public float duration;

    [HideInInspector] public float offset;
 
    ZombiePooler pooler;

    private void Start()
    {
        pooler = ZombiePooler.Instance;
      
    }

    private void OnEnable()
    {
        PlayerGrabController.onCorpseGrabbed += SpawnCorpse;
    }

    private void OnDisable()
    {
        PlayerGrabController.onCorpseGrabbed -= SpawnCorpse;
    }
    public void SpawnCorpse()
    {
        spawnedCorpse = true;

        offset += 0.5f;

        duration += 0.015f;

        pooler.SpawnFromPool(id, new Vector3(player.transform.position.x, player.transform.position.y + offset, player.transform.position.z), Quaternion.identity);
    }
}
