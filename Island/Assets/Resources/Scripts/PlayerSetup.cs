using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovementAdvanced movement;
    public GameObject camera;

    public RoomManager roomManager;
    public SkinnedMeshRenderer arm1;
    public SkinnedMeshRenderer arm2;
    public SkinnedMeshRenderer leg1;
    public SkinnedMeshRenderer leg2;
    public SkinnedMeshRenderer eye1;
    public SkinnedMeshRenderer eye2;

    public GameObject arm1r;
    public GameObject arm2r;
    public GameObject leg1r;
    public GameObject leg2r;
    public GameObject eye1r;
    public GameObject eye2r;

    public string nickname;
    public TextMeshPro nameText;

    public Material blue;
    public Material pink;

    public string PlayerColor;

    public void Start()
    {
       PlayerColor = PlayerPrefs.GetString("Color");
        this.gameObject.GetComponent<PhotonView>().RPC("ChangeColor", RpcTarget.AllBuffered, PlayerColor);
    }

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
        LimbDissapper();
    }

    [PunRPC]
    public void SetNickname(string name)
    {
        nickname = name;
        nameText.text = nickname;
    }

    public void LimbDissapper()
    {
        arm1.enabled = false;
        arm2.enabled = false;
        leg1.enabled = false;
        leg2.enabled = false;
        eye1.enabled = false;
        eye2.enabled = false;
    }

    [PunRPC]
    public void ChangeColor(string playercolor)
    {
        if (playercolor == null)
        {
            return;
        }
        if (playercolor == "Green")
        {
            return;
        }
        if (playercolor == "Blue")
        {
            arm1.material = blue;
            arm2.material = blue;
            leg1.material = blue;
            leg2.material = blue;
        }
        if (playercolor == "Pink")
        {
            arm1.material = pink;
            arm2.material = pink;
            leg1.material = pink;
            leg2.material = pink;
        }
    }
}
