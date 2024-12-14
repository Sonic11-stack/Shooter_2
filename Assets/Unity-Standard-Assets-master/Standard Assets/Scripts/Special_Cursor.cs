using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Cursor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
