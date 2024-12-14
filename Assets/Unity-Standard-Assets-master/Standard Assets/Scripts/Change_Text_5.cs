using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Text_5 : MonoBehaviour
{
    public Text text_6;

    [SerializeField] private Turn_On_Keys turn_on_keys;

    [SerializeField] private Enter_House enter_house;

    [SerializeField] private Turn_Off_Text turn_off_text;
    void Start()
    {
        text_6 = GameObject.FindGameObjectWithTag("Text_6").GetComponent<Text>();
        HideObject();
    }

    
    void Update()
    {
        Check_Keys();
    }
    void Check_Keys()
    {
        switch(turn_on_keys.check_6)
        {
            case true:
                OpenObject();
                
                break;
        }
        switch (enter_house.check_final)
        {
            case true:
                HideObject();
                break;

        }
        switch(turn_off_text.check_text)
        {
            case true:
                HideObject();
                break;
        }
    }
    void OpenObject()
    {
        text_6.enabled = true;
    }
    void HideObject()
    {
        text_6.enabled = false;
    }
}
