using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; // �������� ����� �������
    [SerializeField] private float explosionRadius = 5f; // ������ ������
    [SerializeField] private float explosionForce = 700f; // ���� ������
    [SerializeField] private GameObject explosionEffect; // ������ ������ (��������, �������)

    private void Start()
    {
        // �������� ������ ������
        Invoke(nameof(Explode), explosionDelay);
    }

    private void Explode()
    {
        // ������� ������ ������
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // ������� ��� ������� � ������� ������
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // ��������� �������� ���� � �������� � Rigidbody
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // ���������� ������� ����� ������
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // ������ ����� ������� ������ � ��������� ��� ������������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
