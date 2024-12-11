using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab; 
    [SerializeField] private Transform throwPoint; 
    [SerializeField] private float throwForce = 10f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            ThrowGrenade();
        }
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
        }
    }
}
