using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab; 
    [SerializeField] private Transform throwPoint; 
    [SerializeField] private float throwForce = 10f; 
    [SerializeField] private float upwardForce = 2f;
    [SerializeField] private float grenadeCooldown = 6f;

    [SerializeField] private TakingThing thing;

    [SerializeField] public GameObject scriptToEnable;

    [SerializeField] public GameObject grenade;

    [SerializeField] public ExplosionGrenade expl;

    [SerializeField] public int inventoryGrenade = 2;
    [SerializeField] public int replenishmentGrenade = 2;

    private bool canThrowGrenade = true;

    [SerializeField] public TextMeshProUGUI inventoryGrenadeText;

    private void Start()
    {
        
    }

    void Update()
    {
        UpdateInventoryGrenadeText();
        if (Input.GetKeyDown(KeyCode.F) && canThrowGrenade) 
        {
            if (inventoryGrenade == 0)
            {
                return;
            }

            if (scriptToEnable != null)
            {
                scriptToEnable.SetActive(true);
            }

            inventoryGrenade -= 1;
            expl.TriggerExplosion();
            ThrowGrenade();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grenade"))
        {
            Debug.Log("Player take the grenades!");
            thing.PlayThingMusic();
            GetGrenades();
            Destroy(other.gameObject);
        }
    }
    public void GetGrenades()
    {
        inventoryGrenade += replenishmentGrenade;
    }


    private void ThrowGrenade()
    {
        grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        grenade.SetActive(true);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 forceDirection = throwPoint.forward * throwForce + throwPoint.up * upwardForce;
            rb.AddForce(forceDirection, ForceMode.VelocityChange);
        }

        StartCoroutine(GrenadeCooldown());
    }

    private IEnumerator GrenadeCooldown()
    {
        canThrowGrenade = false; 
        yield return new WaitForSeconds(grenadeCooldown); 
        canThrowGrenade = true; 
    }

    public void UpdateInventoryGrenadeText()
    {
        inventoryGrenadeText.text = $"{inventoryGrenade}";
    }
}
