using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Off_Text : MonoBehaviour
{
    
    public bool check_text = false;
    void Start()
    {

    }

    
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            check_text = true;
        }
    }
}
