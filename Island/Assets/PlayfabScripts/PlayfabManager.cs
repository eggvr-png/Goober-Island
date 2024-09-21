using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    // does... start stuff
    private void Start()
    {
        
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnFail);
    }
    
    // success
    void OnLoginSuccess(LoginResult request)
    {
        Debug.Log("wow, you logged in :D");
    }

    // error
    void OnFail(PlayFabError error)
    {
        Debug.Log("whoops, thats an error: " + error.GenerateErrorReport());
    }
}
