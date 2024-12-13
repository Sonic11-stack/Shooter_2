using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Префаб пули
    [SerializeField] private Transform shootPoint;    // Точка появления пули
    [SerializeField] private float bulletSpeed = 20f; // Скорость полета пули
    [SerializeField] private float bulletLifetime = 2f; // Время существования пули в секундах
    [SerializeField] private float maxDistance = 30f; // Максимальная дистанция полета пули

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject flash;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ для стрельбы
        {
            ShootBullet();

            StartCoroutine(Flash());
            
            /* Vector3 screenCenter = new Vector3(Screen.width/2 , Screen.height/2, 0);
             Ray ray = camera.ScreenPointToRay(screenCenter);
             RaycastHit hit;
          
             if (Physics.Raycast(ray, out hit)) {
             GameObject hitObject = hit.transform.gameObject;
             Enemy target = hitObject.GetComponent<Enemy>();

                 if (target != null) {
                     Debug.Log("Попал");
                 } 
             }
            */
         } 

        }

    private IEnumerator Flash()
    {
        flash.SetActive(true);
        flash.SetActive(false);
        yield return new WaitForSeconds(0.1f);
    }
    private void ShootBullet()
    {
        // Создаем клон пули перед игроком
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

        // Устанавливаем движение пули
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }

        // Уничтожаем пулю через заданное время или после определенного расстояния
        StartCoroutine(DestroyBulletAfterDistance(bullet));
        flash.SetActive(false);
    }

    private IEnumerator DestroyBulletAfterDistance(GameObject bullet)
    {
        float traveledDistance = 0f;
        Vector3 lastPosition = bullet.transform.position;

        while (traveledDistance < maxDistance)
        {
            yield return null; // Ждем следующий кадр
            if (bullet == null) yield break;

            // Считаем пройденное расстояние
            traveledDistance += Vector3.Distance(lastPosition, bullet.transform.position);
            lastPosition = bullet.transform.position;
        }

        if (bullet != null)
        {
            Destroy(bullet);
        }
    }
}