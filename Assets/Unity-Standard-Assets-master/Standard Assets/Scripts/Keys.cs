using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public float rotationSpeed = 50.0f; 

    void Update()
    {
        
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
