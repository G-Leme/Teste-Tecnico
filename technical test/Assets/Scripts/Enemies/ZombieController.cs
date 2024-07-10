using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private float currentTime;
    [SerializeField] private float timeToTurn;

    private List<Collider> ragdollParts = new List<Collider>();

     private Rigidbody rb;

    private Animator animator;

    [HideInInspector] public bool punchedByPlayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        SetRagdoll();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateZombie();

        if(punchedByPlayer == true)
        {
            rb.AddForce(500f * Vector3.up);

            EnableRagdoll();

            punchedByPlayer = false;
        }
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
        
       // rb.useGravity = false;
        rb.velocity = Vector3.zero;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        animator.enabled = false;

        foreach(Collider ragdollColliders in ragdollParts)
        {
            ragdollColliders.isTrigger = false;
            ragdollColliders.attachedRigidbody.velocity = Vector3.zero;
        }
    }

}
