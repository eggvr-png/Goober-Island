using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteractable : MonoBehaviourPunCallbacks
{
    public bool grabbed;
    public Transform grabPoint;
    private Rigidbody rb;
    // public GameObject grabingUI;
    // public GameObject grabbablePrefab;
    // public PlayerStash stash;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ChangeGrab()
    {
        if (grabbed)
        {
            grabbed = false;
            Release();
        }
        else
        {
            grabbed = true;
            Grab();
        }
    }

    private void Update()
    {
        if (grabbed)
        {
            // Optionally, you can interpolate or smooth the position if desired.
            transform.position = Vector3.Lerp(transform.position, grabPoint.position, Time.deltaTime * 10f);
            rb.isKinematic = true; // Disable physics while grabbing
        }
    }

    private void Grab()
    {
        // Optionally, you can perform additional actions when grabbing
        rb.isKinematic = true; // Disable physics while grabbing

    }

    private void Release()
    {
        rb.isKinematic = false; // Re-enable physics when releasing
        // You can optionally add some force or velocity if needed
    }
}
