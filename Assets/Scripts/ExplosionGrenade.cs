using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private float explosionDelay = 3f; // Задержка перед взрывом
    [SerializeField] private float explosionRadius = 5f; // Радиус взрыва
    [SerializeField] private float explosionForce = 700f; // Сила взрыва
    [SerializeField] private GameObject explosionEffect; // Эффект взрыва (например, частицы)

    private void Start()
    {
        // Начинаем таймер взрыва
        Invoke(nameof(Explode), explosionDelay);
    }

    private void Explode()
    {
        // Создаем эффект взрыва
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Находим все объекты в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Применяем взрывную силу к объектам с Rigidbody
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Уничтожаем гранату после взрыва
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Рисуем сферу радиуса взрыва в редакторе для визуализации
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
