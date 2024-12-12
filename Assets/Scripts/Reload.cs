using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public GameObject weaponIcon;

    private void Start()
    {
        weaponIcon = GameObject.Find("ImageReload");
        weaponIcon.SetActive(false);
    }
}
