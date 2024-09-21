using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public string roomName;

    public GameObject Player;
    [Space]
    public Transform spawn; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connectin :D");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Le Server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions: null, typedLobby: null);
        Debug.Log("Joined Room: " + roomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameObject player = PhotonNetwork.Instantiate(Player.name, spawn.position, Quaternion.identity);
    }
}
