using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System;

public class MasterConsole : MonoBehaviourPunCallbacks
{
    public TMP_InputField command;
    public TMP_InputField refrence;
    public GameObject textPrefab;
    public GameObject content;

    public Transform spawnPoint;
    public GameObject grabbingUI;
    public PlayerStash stash;
    public PhotonView meassage;

    public bool svcheats;
    public GameObject console;
    public bool consoleOn = false;

    public bool debounce = false;

    public void Submit()
    {
        if(command.text == "help")
        {
            GameObject text = Instantiate(textPrefab, content.transform);
            text.GetComponent<TextMeshProUGUI>().text = "(0 = disabled, 1 = enabled) All Commands: sv_cheats (default 0): spawn (refrence): disconnect: quit: changeScene (sceneName): goober: sendMeassage (meassage)";
        }
        if(command.text == "sv_cheats")
        {
            if (svcheats) {
                GameObject text = Instantiate(textPrefab, content.transform);
                text.GetComponent<TextMeshProUGUI>().text = "sv_cheats = 1";
            }
            else
            {
                GameObject text = Instantiate(textPrefab, content.transform);
                text.GetComponent<TextMeshProUGUI>().text = "sv_cheats = 0";
            }
        }
        if (command.text == "sv_cheats" && refrence.text == "1")
        {
            svcheats = true;
            GameObject text = Instantiate(textPrefab, content.transform);
            text.GetComponent<TextMeshProUGUI>().text = "sv_cheats = 1";
        }
        if (command.text == "sv_cheats" && refrence.text == "0")
        {
            svcheats = false;
            GameObject text = Instantiate(textPrefab, content.transform);
            text.GetComponent<TextMeshProUGUI>().text = "sv_cheats = 0";
        }
        if (command.text == "spawn" && svcheats)
        {
            this.gameObject.GetComponent<PhotonView>().RPC("SpawnComand", RpcTarget.AllBuffered);
        }
        if(command.text == "disconnect")
        {
            PhotonNetwork.Disconnect();
        }
        if(command.text == "quit")
        {
            Application.Quit();
        }
        if(command.text == "changeScene")
        {
            SceneManager.LoadScene(refrence.text);
        }
        if(command.text == "goober")
        {
            this.gameObject.GetComponent<PhotonView>().RPC("Goober", RpcTarget.AllBuffered);
        }
        if (command.text == "sendMeassage")
        {
            meassage.RPC("Meassage", RpcTarget.AllBuffered, refrence.text, "System");
        }
    }

    [PunRPC]
    public void SpawnComand()
    {
        GameObject objectSpawn = (GameObject)Resources.Load(refrence.text);
        GameObject spawned = PhotonNetwork.Instantiate(objectSpawn.name, spawnPoint.transform.position, Quaternion.identity);
        spawned.name = refrence.text;
        
    }

    [PunRPC]
    public void Goober()
    {
        GameObject objectSpawn = (GameObject)Resources.Load(refrence.text);
        GameObject spawned = PhotonNetwork.Instantiate("goob", spawnPoint.transform.position, Quaternion.identity);
        spawned.name = refrence.text;
        
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (debounce == false)
            {
                debounce = true;
                StartCoroutine(debouncereel());
                if (consoleOn == false)
                {
                    consoleOn = true;
                    console.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                else
                {
                    consoleOn = false;
                    console.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
    }


    public IEnumerator debouncereel()
    {
        yield return new WaitForSeconds(1);
        debounce = false;
    }
}
