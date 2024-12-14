using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Turn_On_Keys : MonoBehaviour
{
     GameObject key_1;
     GameObject key_2;
     GameObject key_3;
     GameObject key_4;
     GameObject key_5;
     GameObject key_6;

    public Text find_key;
    public Text count_of_keys;
    public Text count_of_keys_1;

    GameObject area_house;
    public bool check_6 = false;


    [SerializeField] private Change_Text_4 change_text_4;

    [SerializeField] private Count_Of_Keys count_of_keys_special;

    [SerializeField] private Turn_Off_Text turn_off_text;
    void Start()
    {
        key_1 = GameObject.FindWithTag("key_1");
        key_2 = GameObject.FindWithTag("key_2");
        key_3 = GameObject.FindWithTag("key_3");
        key_4 = GameObject.FindWithTag("key_4");
        key_5 = GameObject.FindWithTag("key_5");
        key_6 = GameObject.FindWithTag("key_6");

        key_1.SetActive(false);
        key_2.SetActive(false);
        key_3.SetActive(false);
        key_4.SetActive(false);
        key_5.SetActive(false);
        key_6.SetActive(false);

        find_key = GameObject.FindGameObjectWithTag("find_key").GetComponent<Text>();
        count_of_keys = GameObject.FindGameObjectWithTag("count_of_key").GetComponent<Text>();
        count_of_keys_1 = GameObject.FindGameObjectWithTag("count_of_key_1").GetComponent<Text>();

        area_house = GameObject.FindWithTag("finish_game");
        area_house.SetActive(false);

        HideObject();
    }

    
    void Update()
    {
        Turn_On_Of_Keys();
    }
    void Turn_On_Of_Keys()
    {
        switch(change_text_4.check_5)
        {
            case true:
                OpenObject();
                if(GameObject.FindWithTag("key_1") == null && GameObject.FindWithTag("key_2") == null && GameObject.FindWithTag("key_3") == null && GameObject.FindWithTag("key_4") == null && GameObject.FindWithTag("key_5") == null && GameObject.FindWithTag("key_6") == null)
                {
                    key_1.SetActive(true);
                    key_2.SetActive(true);
                    key_3.SetActive(true);
                    key_4.SetActive(true);
                    key_5.SetActive(true);
                    key_6.SetActive(true);
                }
                if (count_of_keys_special.check_count == true)
                {
                    HideObject();
                    if (GameObject.FindWithTag("finish_game") == null)
                        area_house.SetActive(true);
                    check_6 = true;
                }
                

                break;
                
        }
        switch(turn_off_text.check_text)
        {
            case true:
                HideObject();
                break;
        }
    }
    public void HideObject()
    {
        find_key.enabled = false;
        count_of_keys.enabled = false;
        count_of_keys_1.enabled = false;
    }

    void OpenObject()
    {
        find_key.enabled = true;
        count_of_keys.enabled = true;
        count_of_keys_1.enabled = true;
    }
}
