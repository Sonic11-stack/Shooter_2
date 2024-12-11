using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGrenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; 
    [SerializeField] private float explosionRadius = 5f; 
    [SerializeField] private float explosionForce = 700f; 
    [SerializeField] private GameObject explosionEffect;


    [SerializeField] private MakeSoundExplosion makeSoundExplosion;
    

    private void Start()
    {
        makeSoundExplosion = GetComponent<MakeSoundExplosion>();

        Invoke(nameof(Explode), explosionDelay);
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            makeSoundExplosion.PlayFirstMusic();
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
