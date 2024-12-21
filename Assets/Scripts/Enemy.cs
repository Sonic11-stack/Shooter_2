using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] public float health = 100f;

    [SerializeField] private ExplosionGrenade explosionGrenade;

    [SerializeField] private AI ai;

    public Image bar;

    [SerializeField] public int hit = 30;

    [SerializeField] private AmmunitionOfAutomaticWeapon ammunitionOfAutomaticWeapon;
    [SerializeField] private AmmunitionOfSniperRifle ammunitionOfSniperRifle;
    [SerializeField] private AmmunitionOfWeaponPistol ammunitionOfWeaponPistol;

    public void GetHit(string bulletType)
    {
        int damage = 0;

        switch (bulletType)
        {
            case "Automatic":
                damage = ammunitionOfAutomaticWeapon.hit; 
                break;

            case "Sniper":
                damage = ammunitionOfSniperRifle.hit; 
                break;

            case "Pistol":
                damage = ammunitionOfWeaponPistol.hit; 
                break;

            default:
                break;
        }

        if (health <= damage)
        {
            health = 0;
            ai.TakeDamage();
            Debug.Log("Враг повержен");
            Destroy(gameObject);
        }

        else
        {
            health -= damage;
            Debug.Log($"Здоровье врага = {health}");
            bar.fillAmount = health / 100;
        }
    }

    public void GetHit1()
    {
        if (health <= explosionGrenade.hit)
        {
            health = 0;
            Debug.Log("Враг повержен");
            Destroy(gameObject);
        }

        else
        {
            health -= explosionGrenade.hit;
            Debug.Log($"Здоровье врага = {health}");
            bar.fillAmount = health / 100;
        }
    }
}