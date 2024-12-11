using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab; 
    [SerializeField] private Transform throwPoint; 
    [SerializeField] private float throwForce = 10f; 
    [SerializeField] private float upwardForce = 2f; 


    private void Start()
    {
        
    }

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
            Vector3 forceDirection = throwPoint.forward * throwForce + throwPoint.up * upwardForce;
            rb.AddForce(forceDirection, ForceMode.VelocityChange);
        }
    }
}
