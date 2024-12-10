using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionOfAutomaticWeapon : MonoBehaviour
{
    [SerializeField] private int inventory = 30;
    [SerializeField] private int maxInventory = 30;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 60;
    [SerializeField] private int total = 60;

    [SerializeField] private TextMeshProUGUI inventoryText;

    [SerializeField] private TakingThing thing;
    [SerializeField] private MakeSoundAutomaticWeapon soundAutomaticWeapon;

    private float fireRate = 0.2f; 
    private float nextFireTime = 0f; 

    private bool canFire = true;
    

    private void Start()
    {
        UpdateInventoryText();
    }

    private void Update()
    {
        UpdateInventoryText();

        if (Input.GetKeyDown(KeyCode.R))
        {
            canFire = false;
            StartCoroutine(ReloadWeapons());
            UpdateInventoryText();
            soundAutomaticWeapon.PlaySecondMusic();
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
