using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionOfSniperRifle : MonoBehaviour
{
    [SerializeField] private int inventory = 5;
    [SerializeField] private int maxInventory = 5;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 3;
    [SerializeField] private int total = 5;

    [SerializeField] private TextMeshProUGUI inventoryText;
    

    [SerializeField] private TakingThing thing;
    [SerializeField] private MakeSoundSniperRifle soundSniper;

    private bool canFire = true;

    private void Start()
    {
        UpdateInventoryText();
    }
    public void Update()
    {
        UpdateInventoryText();

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadWeapons());
            UpdateInventoryText();
            soundSniper.PlaySecondMusic();
        }

        if (Input.GetMouseButtonDown(0) && canFire == true)
        {
            Shoot();
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
            return;
        }
        soundSniper.PlayFirstMusic();
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
