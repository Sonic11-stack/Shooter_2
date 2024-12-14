using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class AmmunitionOfAutomaticWeapon : MonoBehaviour
{
    [SerializeField] private int inventory = 30;
    [SerializeField] private int maxInventory = 30;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 60;
    [SerializeField] private int total = 60;

    [SerializeField] public int hit = 20;

    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform shootPoint;    
    [SerializeField] private float bulletSpeed = 20f; 
    [SerializeField] private float bulletLifetime = 2f; 
    [SerializeField] private float maxDistance = 30f; 

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject flash;

    [SerializeField] private TextMeshProUGUI inventoryText;

    [SerializeField] private TakingThing thing;
    [SerializeField] private MakeSoundAutomaticWeapon soundAutomaticWeapon;

    [SerializeField] private Sprite image;

    [SerializeField] private GameObject imageGoal;

    [SerializeField] private Reload reload;

    public Transform itemInFrontOfCamera;
    public Transform cameraTransform;

    private float fireRate = 0.2f; 
    private float nextFireTime = 0f; 

    private bool canFire = true;
    

    private void Start()
    {
        UpdateInventoryText();
        
    }

    private void LateUpdate()
    {
        if (itemInFrontOfCamera != null)
        {
            if (Input.GetMouseButton(1)) {
                imageGoal.SetActive(false);
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.7f + cameraTransform.up * -0.05f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(180, 0, 180);
            }
            else
            {
                imageGoal.SetActive(true);
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.7f + cameraTransform.right * 0.2f + cameraTransform.up * -0.05f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(180, 0, 180);
            }
            
        }
    }

    private void Update()
    {
        UpdateInventoryText();

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (total > 0)
            {
                reload.weaponIcon.SetActive(true);
                StartCoroutine(ReloadWeapons());
                soundAutomaticWeapon.PlaySecondMusic();
            }
            UpdateInventoryText();
        }

        if (Input.GetMouseButton(0) && canFire == true)
        {
            if (!soundAutomaticWeapon.isShooting)
            {
                soundAutomaticWeapon.isShooting = true;
                soundAutomaticWeapon.PlayFirstMusic(); 
            }


            if (Time.time >= nextFireTime) 
            {
                nextFireTime = Time.time + fireRate; 
                Shoot();
                
                //StartCoroutine(Flash());
            }
        }
        if (Input.GetMouseButtonUp(0) || inventory == 0) 
        {
            if (soundAutomaticWeapon.isShooting)
            {
                soundAutomaticWeapon.isShooting = false;
                soundAutomaticWeapon.StopShootingMusic(); 
            }
        }
    }

    private void ShootBullet(string type)
    {
        GameObject flashWeapon = Instantiate(flash, shootPoint.position, shootPoint.rotation);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation * Quaternion.Euler(90, 0, 0));
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.bulletType = type; 
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }

        StartCoroutine(DestroyBulletAfterDistance(bullet));
        
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
        yield return new WaitForSeconds(3f);

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

    public void Shoot()
    {
        if (inventory == inventoryZero)
        {
            Debug.Log("Out of ammo!");
            return;
        }
        ShootBullet("Automatic");
        soundAutomaticWeapon.PlayFirstMusic();
        inventory -= 1;
        UpdateInventoryText();
        Debug.Log("Player shoot!");
    }

    private void OnTriggerEnter(Collider other)
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
