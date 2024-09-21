using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChat : MonoBehaviour
{
    public KeyCode openChatKey;
    public GameObject chat;

    public RoomManager roomManager;

    private bool debounce;

    public void Update()
    {
        if (debounce)
        {
            return;
        }
        else
        {
            if (Input.GetKey(openChatKey))
            {
                GameObject player = roomManager.spawnedPlayer;
                debounce = true;
                if (chat.active == true)
                {
                    chat.SetActive(false);
                    StartCoroutine(debounceWait());
                    player.GetComponent<PlayerMovementAdvanced>().enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    chat.SetActive(true);
                    StartCoroutine(debounceWait());
                    player.GetComponent<PlayerMovementAdvanced>().enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }

    public IEnumerator debounceWait()
    {
        yield return new WaitForSeconds(1);
        debounce = false;
    }
}
