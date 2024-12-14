using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate_Monster : MonoBehaviour
{
    GameObject high_monster;

    [SerializeField] private Change_Text_4 change_text_4;
    void Start()
    {
        high_monster = GameObject.FindWithTag("Enemy");
        high_monster.SetActive(false);
    }

    
    void Update()
    {
        Turn_On_Monster();
    }
    void Turn_On_Monster()
    {
        switch (change_text_4.check_5)
        {
            case true:
                if (GameObject.FindWithTag("Enemy") == null)
                    high_monster.SetActive(true);
                    break;
        }
    }
}
