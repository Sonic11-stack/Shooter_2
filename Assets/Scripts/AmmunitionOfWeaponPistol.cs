using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionOfWeaponPistol : MonoBehaviour
{
    [SerializeField] private int inventory = 8;
    [SerializeField] private int maxInventory = 8;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 4;
    [SerializeField] private int total = 10;

    [SerializeField] public int hit = 40;

    [SerializeField] private TextMeshProUGUI inventoryText;

    [SerializeField] private TakingThing thing;
    [SerializeField] private MakeSoundPistol soundPistol;

    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform shootPoint;    
    [SerializeField] private float bulletSpeed = 20f; 
    [SerializeField] private float bulletLifetime = 2f; 
    [SerializeField] private float maxDistance = 30f; 

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject flash;

    [SerializeField] private Sprite image;

    [SerializeField] private GameObject imageGoal;

    [SerializeField] private Reload reload;

    public Transform itemInFrontOfCamera;
    public Transform cameraTransform;

    private bool canFire = true;

    private void Start()
    {
        UpdateInventoryText();
    }

    private void LateUpdate()
    {
        if (itemInFrontOfCamera != null)
        {
            if (Input.GetMouseButton(1))
            {
                imageGoal.SetActive(false);
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.7f + cameraTransform.up * -0.05f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(180, 0, 180);
            }

            else
            {
                imageGoal.SetActive(true);
                itemInFrontOfCamera.position = cameraTransform.position + cameraTransform.forward * 0.5f + cameraTransform.right * 0.2f + cameraTransform.up * -0.05f;
                itemInFrontOfCamera.rotation = Quaternion.LookRotation(cameraTransform.forward) * Quaternion.Euler(180, 0, 180);
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
                soundPistol.PlaySecondMusic();
            }
            UpdateInventoryText();
            
        }

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            StartCoroutine(ShootWithCooldown());
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
        yield return new WaitForSeconds(1f);

        if (inventory == maxInventory)
        {
            Debug.Log("Weapons reloaded!");
            canFire = true;
            yield return new WaitForSeconds(0f);
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
        ShootBullet("Pistol");
        soundPistol.PlayFirstMusic();
        inventory -= 1;
        UpdateInventoryText();
        Debug.Log("Player shoot!");
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
