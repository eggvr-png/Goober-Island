using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEditor;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [Header("Player")]
    public GameObject Player;
    public Transform spawn;
    public GameObject spawnedPlayer;
    // connection enum
    public enum ConnectionStatus
    {
        Offline,
        Connecting,
        Connected,
        InLobby
    }
    

    [Header("Status")]
    public ConnectionStatus status;
    [Header("Connecting")]
    public GameObject connectingUI;
    public GameObject overviewCam;
    [Header("Nickname")]
    public NameLobby NameLobby;
    public string nickname = "Player";
    [Header("Misc UI")]
    public TextMeshProUGUI masterText;
    public GameObject MasterUI;
    [Space]
    public GameObject reticle;
    public TextMeshProUGUI interactText;
    public MasterConsole console;
    [Header("NoVis Layer")]
    public LayerMask NonVisable;

    public void Start()
    {
        NameLobby.GetNameAndLobby();
        ChangeNickname(NameLobby.name);
        Connect();
        
    }

    // Start is called before the first frame update
    public void Connect()
    {
        Debug.Log("Connecting!");
        status = ConnectionStatus.Connecting;
        PhotonNetwork.ConnectUsingSettings();
        connectingUI.SetActive(true);
    }

    public void ChangeNickname(string name)
    {
        nickname = name;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected!");
        status = ConnectionStatus.Connected;
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom(NameLobby.lobby, null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        status = ConnectionStatus.InLobby;
        connectingUI.SetActive(false);
        overviewCam.SetActive(false);
        GameObject player = PhotonNetwork.Instantiate(Player.name, spawn.position, Quaternion.identity);
        player.SetActive(true);
        player.GetComponent<PlayerSetup>().IsLocalPlayer();
        player.GetComponent<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickname);
        player.GetComponent<PlayerSetup>().roomManager = this;
        spawnedPlayer = player;
        reticle.SetActive(true);
        if (PhotonNetwork.IsMasterClient)
        {
            masterText.text = "master: yes";
            MasterUI.SetActive(true);
        }
        else
        {
            masterText.text = "master: no";
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            MasterUI.SetActive(true);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            MasterUI.SetActive(true);
        }
    }
}
