using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public bool canBeGrabbed;

    private void OnEnable()
    {
        canBeGrabbed = true;
    }

    private void OnDisable()
    {
        canBeGrabbed = false;
        this.enabled = false;
    }
}
