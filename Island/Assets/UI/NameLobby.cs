using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLobby : MonoBehaviour
{
    public GameObject nameWin;
    public GameObject lobbyWin;
    [Space]
    public string lobbyPP;
    public string namePP;
    [Space]
    public string name;
    public string lobby;

    public void GetNameAndLobby()
    {
        name = PlayerPrefs.GetString(namePP);
        lobby = PlayerPrefs.GetString(lobbyPP);
    }

    public void setName(string name)
    {
        PlayerPrefs.SetString(namePP, name);
    }

    public void setLobby(string lobby)
    {
        PlayerPrefs.SetString(lobbyPP, lobby);
        
    }

    public void changetoName()
    {
        lobbyWin.SetActive(false);
        nameWin.SetActive(true);
    }
}
