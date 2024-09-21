using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cosmetics : MonoBehaviour
{
    public int currentHat;
    public int lastHat;

    public GameObject hatView;
    public RawImage imageHat;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Hat") == 0)
        {
            Debug.Log("NoHat");
            if (PlayerPrefs.GetInt("LastHat") == 0)
            {
                Debug.Log("NoPreviousHat");
            }
        }
        else
        {
            currentHat = PlayerPrefs.GetInt("Hat");
            lastHat = PlayerPrefs.GetInt("LastHat");
        }

        if (currentHat == 0)
        {
            hatView.SetActive(false);
        }
        else
        {
            hatView.SetActive(true);
            Texture2D hatTexture = Resources.Load<Texture2D>(currentHat.ToString());
            imageHat.texture = hatTexture;
        }
    }

    public void ChangeHat(int hat)
    {
        if(currentHat > 0)
        {
            lastHat = currentHat;
            PlayerPrefs.SetInt("LastHat", lastHat);
        }
        PlayerPrefs.SetInt("Hat", hat);
        currentHat = hat;
        if (currentHat == 0)
        {
            hatView.SetActive(false);
        }
        else
        {
            hatView.SetActive(true);
            Texture2D hatTexture = Resources.Load<Texture2D>(currentHat.ToString());
            imageHat.texture = hatTexture;
        }
    }
}
