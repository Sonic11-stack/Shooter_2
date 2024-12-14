using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dead_Man : MonoBehaviour
{
    GameObject dead_man;
    GameObject area_of_man;
    GameObject area_of_man_1;
    GameObject area_of_blood;
    Text text_5_1;

    [SerializeField] private Change_Text_2 change_text_2_1;

    void Start()
    {
        dead_man = GameObject.FindWithTag("Dead");
        dead_man.SetActive(false);
        area_of_man = GameObject.FindWithTag("area");
        area_of_man.SetActive(false);
        area_of_man_1 = GameObject.FindWithTag("area_1");
        area_of_man_1.SetActive(false);
        area_of_blood = GameObject.FindWithTag("blood");
        area_of_blood.SetActive(false);
        text_5_1 = GameObject.FindGameObjectWithTag("Text_5").GetComponent<Text>();
        text_5_1.enabled = false;
    }


    void Update()
    {
        Checking_After_House_For_Search_Human();
    }
    void Checking_After_House_For_Search_Human()
    {
        switch (change_text_2_1.check_2)
        {
            case false:
                if (GameObject.FindWithTag("Dead") == null)
                {
                    dead_man.SetActive(true);
                    
                }
                if (GameObject.FindWithTag("area") == null)
                {
                    area_of_man.SetActive(true);
                }
                if (GameObject.FindWithTag("area_1") == null)
                {
                    area_of_man_1.SetActive(true);
                }
                if (GameObject.FindWithTag("blood") == null)
                {
                    area_of_blood.SetActive(true);
                }

                break;
        }
    }
}
