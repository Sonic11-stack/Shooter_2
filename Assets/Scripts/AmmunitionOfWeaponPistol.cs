using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmunitionOfWeaponPistol : MonoBehaviour
{
    [SerializeField] private int inventory = 8;
    [SerializeField] private int maxInventory = 8;
    [SerializeField] private int inventoryZero = 0;
    [SerializeField] private int replenishment = 4;
    [SerializeField] private int total = 10;

    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private TextMeshProUGUI inventoryText_1;

    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    [SerializeField] private AudioClip audioClip_1;
    private AudioSource audioSource_1;

    

    [SerializeField] private TakingThing thing;

    private void Start()
    {

        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            audioSource = audioSources[0];
            audioSource_1 = audioSources[1];
            
        }

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        if (audioClip_1 != null)
        {
            audioSource_1.clip = audioClip_1;
        }

        

        UpdateInventoryText();
        UpdateInventoryTotalText();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadWeapons();
            UpdateInventoryText();
            UpdateInventoryTotalText();
            PlaySecondMusic();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void ReloadWeapons()
    {
        if (inventory == maxInventory)
        {
            Debug.Log("Weapons reloaded!");
            return;
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

            Debug.Log("Weapons reloaded!");
            UpdateInventoryText();
            UpdateInventoryTotalText();
        }
    }

    public void GetBullets()
    {
        total += replenishment;
        UpdateInventoryTotalText();
    }

    public void Shoot()
    {
        if (inventory == inventoryZero)
        {
            return;
        }
        PlayFirstMusic();
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
        inventoryText.text = $"{inventory}";
    }

    private void UpdateInventoryTotalText()
    {
        inventoryText_1.text = $"/ {total}";
    }

    void PlayFirstMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    void PlaySecondMusic()
    {
        if (!audioSource_1.isPlaying)
        {
            audioSource_1.Play();
        }
    }
    
}
