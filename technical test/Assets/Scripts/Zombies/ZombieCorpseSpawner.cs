using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieCorpseSpawner : MonoBehaviour
{

    
    [SerializeField] private string id;

    [SerializeField] private GameObject player;

    ZombiePooler pooler;

    [HideInInspector] public float delay;


    [HideInInspector] public float offset;
    void Awake()
    {
  
       
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCorpse()
    {
        offset += 0.5f;
        delay += 0.015f;
        pooler.SpawnFromPool(id, new Vector3(player.transform.position.x, player.transform.position.y + offset, player.transform.position.z), Quaternion.identity);
        Debug.Log(offset);
    }
}
