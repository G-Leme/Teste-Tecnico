using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class PlayerDropCorpseController : MonoBehaviour
{


    [SerializeField] private Button dropButton;

    [SerializeField] private bool insideDropArea;

   [HideInInspector] public GameObject[] zombieCorpse;

    public static event Action onCorpseDropped;

    private PlayerGrabController GrabController;

    ZombieCorpseSpawner corpseSpawner;

    void Awake()
    {
        GrabController = GetComponent<PlayerGrabController>();
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

            onCorpseDropped?.Invoke();
            corpseSpawner.spawnedCorpse = false;
            corpseSpawner.offset = 0;
            corpseSpawner.duration = 0;
            GrabController.currentlyCarrying = 0;
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
