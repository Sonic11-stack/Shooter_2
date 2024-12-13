using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public float health = 100f;
    
    public Image bar;

    [SerializeField] public int hit = 30;

    public void GetHit()
    {
        if (health <= hit)
        {
            health = 0;
            Debug.Log("Враг повержен");
            Destroy(gameObject);
        }
            
        else
        {
            health -= hit;
            Debug.Log($"Здоровье врага = {health}");
            bar.fillAmount = health / 100;
        }
    }
    
}
