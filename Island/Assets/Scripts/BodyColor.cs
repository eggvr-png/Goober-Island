using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyColor : MonoBehaviour
{
    public RawImage body;
    private Color color = Color.green;

    public void Start()
    {
        string PlayerColor = PlayerPrefs.GetString("Color");
        if (PlayerColor == null || PlayerColor == "")
        {
            body.color = Color.green;
        }
        if (PlayerColor == "Green")
        {
            body.color = Color.green;
        }
        if (PlayerColor == "Blue")
        {
            body.color = Color.blue ;
        }
        if (PlayerColor == "Pink")
        {
            body.color = Color.magenta;
        }
    }

    public void Change(string colortoChange)
    {
        
        if (colortoChange == "green") {
            color = Color.green;
            body.color = color;
            PlayerPrefs.SetString("Color", "Green");
        }
        if (colortoChange == "blue")
        {
            color = Color.blue;
            body.color = color;
            PlayerPrefs.SetString("Color", "Blue");
        }
        if (colortoChange == "pink")
        {
            color = Color.magenta;
            body.color = color;
            PlayerPrefs.SetString("Color", "Pink");
        }
    }
}
