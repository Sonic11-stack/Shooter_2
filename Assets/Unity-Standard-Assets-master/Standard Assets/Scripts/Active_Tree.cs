using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Tree : MonoBehaviour
{
    public GameObject monstr;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            monstr.active = true;
            
        }
    }
}
