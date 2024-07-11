using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private float timeToTurn;

    [SerializeField] private float pushedForce;

    private List<Collider> ragdollParts = new List<Collider>();

    private PlayerController playerTransform;

     private Rigidbody rb;

    private Animator animator;

    [HideInInspector] public bool punchedByPlayer;

    private bool ragdollEnabled;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        playerTransform = FindFirstObjectByType<PlayerController>();

        SetRagdoll();
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

            punchedByPlayer = false;
            ragdollEnabled = true;
        }
        
        if(ragdollEnabled == false)
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

        foreach(Collider ragdollColliders in ragdollParts)
        {
            ragdollColliders.isTrigger = false;
            ragdollColliders.attachedRigidbody.velocity = Vector3.zero;
            ragdollColliders.attachedRigidbody.AddForce(force, ForceMode.Impulse);
        }
    }

}
