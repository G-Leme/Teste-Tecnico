using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerGrabController : MonoBehaviour
{
    [SerializeField] private Button grabButton;

    [SerializeField] private bool isGrabbable;

    [SerializeField]  private GameObject zombieRagdoll;

    public static event Action onCorpseGrabbed;

    void Start()
    {
        
    }

    private void Awake()
    {
        grabButton.onClick.AddListener(OnButtonGrabTouch);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>() == null)
            return;

        else if (other.GetComponent<GrabbableObject>().enabled != false && other.GetComponent<GrabbableObject>() != null)
        {
            zombieRagdoll = other.GetComponentInParent<ZombieController>().gameObject ;
            isGrabbable = true;

        }
        else
            isGrabbable = false;
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<GrabbableObject>() == null)
            return;

        if (other.GetComponent<GrabbableObject>().enabled != false && other.GetComponent<GrabbableObject>() != null)
        {
            isGrabbable = true;
            zombieRagdoll = other.GetComponentInParent<ZombieController>().gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isGrabbable = false;
    }

    private void OnButtonGrabTouch()
    {
        if(isGrabbable == true)
        {
            zombieRagdoll.SetActive(false);
            Debug.Log("Grabbed zombie");
            isGrabbable = false;
            onCorpseGrabbed?.Invoke();
            
        }
    }
}
