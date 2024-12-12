using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGrenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; 
    [SerializeField] private float explosionRadius = 5f; 
    [SerializeField] private float explosionForce = 700f; 
    [SerializeField] private GameObject explosionEffect;

    public GameObject objectToDestroy;

    public bool explodeGrenade = false;

    [SerializeField] private GrenadeThrower grenadeThrower;

    [SerializeField] private MakeSoundExplosion makeSoundExplosion;
    

    private void Start()
    {
        makeSoundExplosion = gameObject.AddComponent<MakeSoundExplosion>();

        Invoke(nameof(Explode), explosionDelay);
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            //makeSoundExplosion.PlayFirstMusic();
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            explosion.transform.position = grenadeThrower.grenade.transform.position;
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

        if (objectToDestroy != null)
        {
            Destroy(grenadeThrower.grenade); 
            objectToDestroy = null; 
        }

        explodeGrenade = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
