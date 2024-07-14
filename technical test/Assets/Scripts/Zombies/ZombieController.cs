using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float timeToTurn;

    [SerializeField] private float pushedForce;

    [HideInInspector] public bool punchedByPlayer;

    [HideInInspector] public bool isInRagdoll;

    private GrabbableObject grabbableObject;

    private float currentTime;

    private List<Collider> ragdollParts = new List<Collider>();

    private PlayerController playerTransform;

    private Rigidbody rb;

    private Animator animator;
   


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        playerTransform = FindFirstObjectByType<PlayerController>();

        grabbableObject = GetComponentInChildren<GrabbableObject>();

        SetRagdoll();
    }

    private void OnEnable()
    {
        DisableRagdoll();
    }

    private void OnDisable()
    {
        StopCoroutine(DisableObject());
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if(punchedByPlayer == true)
        {

            EnableRagdoll();
            StartCoroutine(DisableObject());
            punchedByPlayer = false;
           
        }
        
        if(isInRagdoll  == false)
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

    private void SetRagdoll()
    {
        Collider[] ragdollColliders = this.GetComponentsInChildren<Collider>();

        foreach (Collider colliders in ragdollColliders)
        {
            if(colliders.gameObject != this.gameObject)
            {
                colliders.isTrigger = true;
                ragdollParts.Add(colliders);
            }

            
        }
    }

    private void EnableRagdoll()
    {
        Vector3 direction  = transform.position - playerTransform.gameObject.transform.position;
        Vector3 force = direction * pushedForce;

        rb.useGravity = false;

        rb.velocity = Vector3.zero;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        animator.enabled = false;

        grabbableObject.enabled = true;

        isInRagdoll = true;

        foreach (Collider ragdollColliders in ragdollParts)
        {
            ragdollColliders.isTrigger = false;
            ragdollColliders.attachedRigidbody.velocity = Vector3.zero;
            ragdollColliders.attachedRigidbody.AddForce(force, ForceMode.Impulse);
            
        }
    }

    private void DisableRagdoll()
    {
        rb.useGravity = true;

        rb.velocity = Vector3.zero;

        gameObject.GetComponent<BoxCollider>().enabled = true;

        animator.enabled = true;    

        foreach (Collider ragdollColliders in ragdollParts)
        {
            ragdollColliders.isTrigger = true;
          
            ragdollColliders.attachedRigidbody.velocity = Vector3.zero;
          
        }
        isInRagdoll = false;
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(14f);

        //Sets the zombie ragdoll position to a random place to prevent bad interaction with other code
        transform.position = new Vector3(0, 200, 0);

        yield return new WaitForSeconds(1f);

        //Disables both the zombie Gameobject & the grabbable script
        grabbableObject.enabled = false;
        gameObject.SetActive(false);
    }

}
