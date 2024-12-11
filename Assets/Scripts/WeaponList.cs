using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponList : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string name; 
        public int damage;  
        public float range; 
        public GameObject weaponObject; 
        public MonoBehaviour specificScript;
        public GameObject weaponIcon;
    }

    public List<Weapon> weapons = new List<Weapon>();

    private int currentWeaponIndex = 0; 

    void Start()
    {
        // Добавляем оружие в список
        weapons.Add(new Weapon
        {
            name = "Sniper Rifle",
            damage = 100,
            range = 30f,
            weaponObject = GameObject.Find("SniperRifle"),
            specificScript = GetComponent<AmmunitionOfSniperRifle>(),
            weaponIcon = GameObject.Find("ImageSniperRifle")
        });

        weapons.Add(new Weapon
        {
            name = "Automatic Weapon",
            damage = 30,
            range = 15.0f,
            weaponObject = GameObject.Find("AutomaticWeapon"),
            specificScript = GetComponent<AmmunitionOfAutomaticWeapon>(),
            weaponIcon = GameObject.Find("ImageAutomaticWeapon")
        });

        weapons.Add(new Weapon
        {
            name = "Pistol",
            damage = 20,
            range = 10.0f,
            weaponObject = GameObject.Find("Pistol"),
            specificScript = GetComponent<AmmunitionOfWeaponPistol>(),
            weaponIcon = GameObject.Find("ImagePistol")
        });

        ActivateWeapon(currentWeaponIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0); 
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1); 
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2); 
    }

    private void SelectWeapon(int index)
    {
        if (index >= 0 && index < weapons.Count)
        {
            currentWeaponIndex = index; 
            ActivateWeapon(currentWeaponIndex); 
        }
        else
        {
            Debug.LogWarning("Неверный индекс оружия: " + index);
        }
    }

    private void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            bool isActive = (i == index);
            weapons[i].weaponObject.SetActive(isActive);
            ToggleSpecificScript(weapons[i].specificScript, isActive);

            if (weapons[i].weaponIcon != null)
            {
                weapons[i].weaponIcon.SetActive(isActive); 
            }
        }

        DisplayCurrentWeapon();
    }

    private void ToggleSpecificScript(MonoBehaviour script, bool enable)
    {
        if (script != null)
        {
            script.enabled = enable; 
        }
        else
        {
            Debug.LogWarning("Скрипт не найден!");
        }
    }

    private void DisplayCurrentWeapon()
    {
        Weapon currentWeapon = weapons[currentWeaponIndex];
        Debug.Log($"Текущее оружие: {currentWeapon.name}, Урон: {currentWeapon.damage}, Дальность: {currentWeapon.range}");
    }
}
