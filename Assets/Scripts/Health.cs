using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public int health = 100;
    [SerializeField] private int firstAidKit = 50;

    [SerializeField] private int hit = 30;

    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private TakingThing thing;


    private void Start()
    {
        UpdateHealthText();
    }

    private void Update()
    {
        UpdateHealthText();
    }

    public void GetHealth()
    {
        if (maxHealth - health <= 50)
            health = maxHealth;

        else if (maxHealth - health >= 50)
            health += firstAidKit;
    }

    public void GetHit()
    {
        if (health <= hit)
            health = 0;
        else
            health -= hit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("firstAidKit") && health != 100)
        {
            GetHealth();
            thing.PlayThingMusic();
            Debug.Log("Player take the first aid kit!");
            Destroy(other.gameObject);
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = $"{health}";
    }

    
}
