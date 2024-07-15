using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class PlayerGrabController : MonoBehaviour
{
    [SerializeField] private Button grabButton;

    [SerializeField] private bool isGrabbable;

    [SerializeField]  private GameObject zombieRagdoll;

    [SerializeField] private TextMeshProUGUI currentCarryCapacity;

    [HideInInspector] public int currentlyCarrying;

    public static event Action onCorpseGrabbed;

    public int maximumCarryAmmount;




    private void Awake()
    {
        grabButton.onClick.AddListener(OnButtonGrabTouch);
    }
    void Update()
    {
      currentCarryCapacity.text = "PEGAR (max " + maximumCarryAmmount + ")";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>() == null)
            return;

        else if (other.GetComponent<GrabbableObject>().enabled != false && other.GetComponent<GrabbableObject>() != null && currentlyCarrying < maximumCarryAmmount)
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

        if (other.GetComponent<GrabbableObject>().enabled != false && other.GetComponent<GrabbableObject>() != null && currentlyCarrying < maximumCarryAmmount)
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
            currentlyCarrying += 1;

            zombieRagdoll.SetActive(false);

            isGrabbable = false;

            onCorpseGrabbed?.Invoke();
        }
    }
}
