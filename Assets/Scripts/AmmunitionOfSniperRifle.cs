using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionOfSniperRifle : MonoBehaviour
{
    [SerializeField] private int inventory = 5;
    [SerializeField] private int maxInventory = 5;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 3;
    [SerializeField] private int total = 5;

    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform shootPoint1;
    [SerializeField] private GameObject shootPoint_1;
    [SerializeField] private GameObject shootPoint_1_2;
    [SerializeField] private float bulletSpeed = 20f; 
    [SerializeField] private float bulletLifetime = 2f; 
    [SerializeField] private float maxDistance = 30f; 

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject flash;

    [SerializeField] private TextMeshProUGUI inventoryText;
    

    [SerializeField] private TakingThing thing;
    [SerializeField] private MakeSoundSniperRifle soundSniper;

    [SerializeField] private Sprite image;

    [SerializeField] private GameObject imageGoal;


    [SerializeField] private Reload reload;

    public Transform itemInFrontOfCamera;
    public Transform itemInFrontOfCamera1;
    public Transform cameraTransform;

    private bool canFire = true;

    [SerializeField] private Camera mainCamera; 
    [SerializeField] private float normalFOV = 60f; 
    [SerializeField] private float zoomedFOV = 30f; 
    [SerializeField] private float zoomSpeed = 5f;

    private void Start()
    {
        camera = GetComponent<Camera>();
        UpdateInventoryText();
    }

    private void LateUpdate()
    {
        if (itemInFrontOfCamera != null)
        {
            if (Input.GetMouseButton(1))
            {
                shootPoint_1.SetActive(false);
                shootPoint_1_2.SetActive(true);
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomedFOV, Time.deltaTime * zoomSpeed);
                imageGoal.SetActive(false);
                //itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.4f;
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * -1.6f + cameraTransform.right * -0.02f + cameraTransform.up * -0.3f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(0, 90, 0);
                itemInFrontOfCamera1.position = cameraTransform.position + cameraTransform.forward * -1.6f + cameraTransform.right * -0.02f + cameraTransform.up * -0.3f;
                itemInFrontOfCamera1.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(0, 90, 0);
            }

            else {
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, Time.deltaTime * zoomSpeed);
                shootPoint_1.SetActive(true);
                shootPoint_1_2.SetActive(false);
                imageGoal.SetActive(true);
                //itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.4f + cameraTransform.up * -0.3f;
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * -0.4f + cameraTransform.right * 0.4f + cameraTransform.up * -0.3f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(0, 90, 0);
                itemInFrontOfCamera1.position = cameraTransform.position + cameraTransform.forward * -0.4f + cameraTransform.right * 0.4f + cameraTransform.up * -0.3f;
                itemInFrontOfCamera1.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(0, 90, 0);
            }
            
            
        }

        
    }

    public void Update()
    {
        UpdateInventoryText();

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (total > 0)
            {
                reload.weaponIcon.SetActive(true);
                StartCoroutine(ReloadWeapons());
                soundSniper.PlaySecondMusic();
            }
            UpdateInventoryText();
        }

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            StartCoroutine(ShootWithCooldown());
        }
    }


    
    private void ShootBullet()
    {
        GameObject flashWeapon = Instantiate(flash, shootPoint.position, shootPoint.rotation);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation * Quaternion.Euler(90, 0, 0));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }

        StartCoroutine(DestroyBulletAfterDistance(bullet));
    }

    private void ShootBullet1()
    {
        GameObject flashWeapon = Instantiate(flash, shootPoint.position, shootPoint.rotation);

        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

    Vector3 targetPoint;
    if (Physics.Raycast(ray, out hit, maxDistance))
    {
        targetPoint = hit.point; 
    }
    else
    {
        targetPoint = ray.GetPoint(maxDistance); 
    }

    Vector3 direction = (targetPoint - shootPoint.position).normalized;

    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.velocity = direction * bulletSpeed;
    }

    Destroy(bullet, bulletLifetime);
    }

    private IEnumerator DestroyBulletAfterDistance(GameObject bullet)
    {
        float traveledDistance = 0f;
        Vector3 lastPosition = bullet.transform.position;

        while (traveledDistance < maxDistance)
        {
            yield return null; 
            if (bullet == null) yield break;

            traveledDistance += Vector3.Distance(lastPosition, bullet.transform.position);
            lastPosition = bullet.transform.position;
        }

        if (bullet != null)
        {
            Destroy(bullet);
        }
    }

    public IEnumerator ReloadWeapons()
    {
        canFire = false;
        yield return new WaitForSeconds(4f);

        if (inventory == maxInventory)
        {
            Debug.Log("Weapons reloaded!");
        }
        else if (inventory < maxInventory && total > 0)
        {
            int bulletsNeeded = maxInventory - inventory;

            if (total >= bulletsNeeded)
            {
                total -= bulletsNeeded;
                inventory = maxInventory;
            }
            else
            {
                inventory += total;
                total = 0;
            }

            canFire = true;
            Debug.Log("Weapons reloaded!");
            UpdateInventoryText();
            reload.weaponIcon.SetActive(false);
        }
    }

    public void GetBullets()
    {
        total += replenishment;
        UpdateInventoryText();
    }

    private IEnumerator ShootWithCooldown()
    {
        if (inventory == inventoryZero)
        {
            yield break; 
        }

        canFire = false; 
        Shoot(); 
        yield return new WaitForSeconds(1f); 
        canFire = true; 
    }

    public void Shoot()
    {
        if (shootPoint_1 == false)
        {
            ShootBullet1();
            soundSniper.PlayFirstMusic();
            inventory -= 1;
            UpdateInventoryText();
            Debug.Log("Player shoot!");
        }
        else
        {
            ShootBullet();
            soundSniper.PlayFirstMusic();
            inventory -= 1;
            UpdateInventoryText();
            Debug.Log("Player shoot!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullets"))
        {
            Debug.Log("Player take the bullets!");
            thing.PlayThingMusic();
            GetBullets();
            Destroy(other.gameObject);
        }
    }

    private void UpdateInventoryText()
    {
        inventoryText.text = $"{inventory} / {total}";
    }
}
