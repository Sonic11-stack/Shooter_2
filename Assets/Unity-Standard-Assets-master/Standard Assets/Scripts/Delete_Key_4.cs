using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_Key_4 : MonoBehaviour
{
    [SerializeField] private Count_Of_Keys count_of_keys;
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

            Destroy(this.gameObject);
            count_of_keys.count++;

        }
    }
}
