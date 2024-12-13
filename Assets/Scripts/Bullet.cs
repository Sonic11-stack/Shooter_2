using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject dentBullet;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector3 hitPoint = transform.position;

                enemy.GetHit();
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Things"))
        {
            Vector3 hitPoint = transform.position;

            Vector3 hitNormal = (transform.position - other.ClosestPoint(transform.position)).normalized;

            Quaternion rotation = Quaternion.LookRotation(hitNormal);

            Instantiate(dentBullet, hitPoint, rotation * Quaternion.Euler(0, 0, 0));

            Destroy(gameObject);
        }
    }
}
