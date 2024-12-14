using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_tree : MonoBehaviour
{
    public GameObject monstr;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") ;
        monstr.active = false;
        //Destroy(monstr); 
    }
}
