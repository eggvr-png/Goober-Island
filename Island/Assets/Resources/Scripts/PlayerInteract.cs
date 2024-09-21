using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInteract : MonoBehaviourPunCallbacks
{
    Ray ray;

    public GameObject objhit;
    public Transform rayLength;
    public KeyCode interactKey = KeyCode.E;

    public float waitTime = 0.2f;
    public bool abletoInteract;
    [SerializeField] private PlayerSetup playerSetup;

    private void Start()
    {
        playerSetup = this.gameObject.GetComponentInParent<PlayerSetup>();
    }

    private void Update()
    {
        CheckForCollioson();
    }

    void CheckForCollioson()
    {
        if (Physics.Linecast(transform.position, rayLength.position, out RaycastHit hit))
        {
            objhit = hit.collider.gameObject;
            if (hit.collider.gameObject.tag == "EDInteractableRadio")
            {
                playerSetup.roomManager.interactText.text = "Enable/Disable";
                if (Input.GetKey(interactKey))
                {
                    if (abletoInteract)
                    {
                        EDInteractableRadio script = objhit.GetComponent<EDInteractableRadio>();
                        script.GetComponentInParent<PhotonView>().RPC("enableDisableRadio", RpcTarget.All);
                        StartCoroutine(wait());
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (hit.collider.gameObject.tag == "Grababble")
            {
                playerSetup.roomManager.interactText.text = "Grab";
                if (Input.GetKey(interactKey))
                {
                    if (abletoInteract)
                    {
                        GrabInteractable script = objhit.GetComponent<GrabInteractable>();
                        script.grabPoint = rayLength;
                        script.ChangeGrab();
                        StartCoroutine(wait());
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (hit.collider.gameObject.tag == "EDInteractable")
            {
                playerSetup.roomManager.interactText.text = "Enable/Disable";
                if (Input.GetKey(interactKey))
                {
                    if (abletoInteract)
                    {
                        EDInteractable script = objhit.GetComponent<EDInteractable>();
                        script.GetComponentInParent<PhotonView>().RPC("enableDisable", RpcTarget.All);
                        StartCoroutine(wait());
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        else {
            playerSetup.roomManager.interactText.text = "";
        }
    }

    IEnumerator wait()
    {
        abletoInteract = false;
        yield return new WaitForSeconds(waitTime);
        abletoInteract = true;
    }
}
