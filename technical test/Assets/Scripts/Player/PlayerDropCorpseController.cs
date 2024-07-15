using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDropCorpseController : MonoBehaviour
{

   [SerializeField] private GameObject[] zombieCorpse;

    [SerializeField] private Button dropButton;

    [SerializeField] private bool insideDropArea;

    ZombieCorpseSpawner corpseSpawner;

    void Awake()
    {
        corpseSpawner = FindAnyObjectByType<ZombieCorpseSpawner>();
        dropButton.onClick.AddListener(OnButtonDropTouch);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnButtonDropTouch()
    {
        if (corpseSpawner.spawnedCorpse == true && insideDropArea == true)
        {
            zombieCorpse = GameObject.FindGameObjectsWithTag("Corpse");

            foreach (GameObject zombieCorpses in zombieCorpse)
            {

                zombieCorpses.SetActive(false);
            }

            corpseSpawner.spawnedCorpse = false;
            corpseSpawner.offset = 0;
            corpseSpawner.duration = 0;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DropArea")
        {
            insideDropArea = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        insideDropArea = false;
    }

}
