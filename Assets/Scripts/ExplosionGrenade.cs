using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGrenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; 
    [SerializeField] private float explosionRadius = 7f; 
    [SerializeField] private float explosionForce = 700f; 
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] public int hit = 60;

    [SerializeField] private TakingThing thing;

    [SerializeField] private Bullet bullet;

    public GameObject objectToDestroy;

    public bool explodeGrenade = false;

    private bool isInvoked = false;

    public GameObject objectToDisable;

    [SerializeField] private GrenadeThrower grenadeThrower;

    [SerializeField] private MakeSoundExplosion makeSoundExplosion;

    [SerializeField] private Health health;

    [SerializeField] private Enemy enemy;

    [SerializeField] private ExplosionGrenade explo;


    private void Start()
    {
        makeSoundExplosion = gameObject.AddComponent<MakeSoundExplosion>();
    }

    public void TriggerExplosion() 
    {
        if (!isInvoked)
        {
            isInvoked = true;
            Invoke(nameof(Explode), explosionDelay);
        }
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            //makeSoundExplosion.PlayFirstMusic();
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            explosion.transform.position = grenadeThrower.grenade.transform.position;
            explo.transform.position = grenadeThrower.grenade.transform.position;
            Destroy(explosion, 2f);
            //  grenadeThrower.scriptToEnable.SetActive(false);
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            if (nearbyObject.CompareTag("Player"))
            {
               
                health.health -= hit;
                
            }
            if (nearbyObject.CompareTag("Enemy"))
            {

                enemy.GetHit1();
                //enemy.health -= hit;

            }
        }

        if (objectToDestroy != null)
        {
            Destroy(grenadeThrower.grenade); 
            
        }

        Invoke(nameof(DisableObject), 2f);

        explodeGrenade = true;
        isInvoked = false;
    }
    private void DisableObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
