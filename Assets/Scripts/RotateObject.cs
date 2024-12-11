using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 90, 0); 

    void Update()
    {

        transform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
    }
}
