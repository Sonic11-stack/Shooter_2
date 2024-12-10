using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    [System.Serializable]
    public class Weapon
    {
        public string name;
        public int damage;
        public float range;
    }

    public List<Weapon> weapons = new List<Weapon>();

    void Start()
    {

        weapons.Add(new Weapon { name = "Sniper Rifle", damage = 100, range = 30f });
        weapons.Add(new Weapon { name = "Automatic Weapon", damage = 30, range = 15.0f });
        weapons.Add(new Weapon { name = "Pistol", damage = 20, range = 10.0f });

    }
}
