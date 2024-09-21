using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCosmetics : MonoBehaviourPunCallbacks
{
    [Header("Refrences")]
    public GameObject hatHolder;
    [Header("Hat")]
    public int hat;
    [SerializeField] private GameObject hatObject;

    public void Start()
    {
        PhotonView player = this.gameObject.GetComponent<PhotonView>();
        hatHolder = this.gameObject;
        hat = PlayerPrefs.GetInt("Hat");
        hat = hat - 1;
        this.gameObject.GetComponent<PhotonView>().RPC("PutOnCosmetics", RpcTarget.AllBuffered, player.ViewID);
        HidePlayerHat();
    }



    [PunRPC]
    public void PutOnCosmetics(int PlayerID)
    {
        PhotonView player = PhotonView.Find(PlayerID);
        GameObject hatHold = this.gameObject;
        if (hat == -1)
        {
            return;
            Debug.Log("no hat dum dum");
        }
        else
        {
            hatHold.transform.GetChild(hat).gameObject.SetActive(true);
            Debug.Log("ooh a hat :0: hat " + hat.ToString());
        }
    }

    public void HidePlayerHat()
    {
        if (hat == -1)
        {
            return;
            Debug.Log("no hat dum dum");
        }
        else
        {
            hatHolder.transform.GetChild(hat).gameObject.SetActive(false);
        }
    }
}
