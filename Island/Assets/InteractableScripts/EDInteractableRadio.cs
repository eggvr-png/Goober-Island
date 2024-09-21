using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EDInteractableRadio : MonoBehaviourPunCallbacks
{
    [Header("Is OBJ enabled?")]
    [Space]
    public bool objEnabled = true;
    [Header("Object to Enable/Disable")]
    public GameObject objToEnableDisable;

    void Update()
    {
        objEnabled = objToEnableDisable.active;
    }

    [PunRPC]
    public void enableDisableRadio()
    {
        if (objEnabled)
        {
            objToEnableDisable.SetActive(false);
        }
        else
        {
            objToEnableDisable.SetActive(true);
        }
    }
}
