using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;
    [SerializeField] private int firstAidKit = 50;

    [SerializeField] private int hit = 30;

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
        if (other.CompareTag("firstAidKit"))
        {
            GetHealth();
            Debug.Log("Player take the first aid kit!");
            Destroy(other.gameObject);
        }
    }
}
