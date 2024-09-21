using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendMeassage : MonoBehaviourPunCallbacks
{
    public RoomManager roomManager;
    public string text;

    public string name;

    public GameObject textPrefab;

    public GameObject content;

    [PunRPC]
    public void Meassage(string meassageContent, string playerName)
    {
        name = playerName;
        GameObject messagePrefab = Instantiate(textPrefab, content.transform);
        messagePrefab.GetComponent<TextMeshProUGUI>().text = "[" + name + "]: " + meassageContent;
    }

    public void SetText(string textM)
    {
        text = textM;
    }

    public void SendTheMeassage()
    {
        this.gameObject.GetComponent<PhotonView>().RPC("Meassage", RpcTarget.All, text, roomManager.nickname);
    }
}
