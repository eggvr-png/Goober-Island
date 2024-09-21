using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenus : MonoBehaviour
{
    public GameObject one;
    public GameObject two;

    public void Switch()
    {
        one.SetActive(false);
        two.SetActive(true);
    }
}
