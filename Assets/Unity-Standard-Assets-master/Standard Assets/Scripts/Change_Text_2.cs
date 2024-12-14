using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Text_2 : MonoBehaviour
{
    
    public bool shouldHide_2 = false;
    
    public bool check_2 = true;
    [SerializeField] private Change_Text_1 change_text_1;

    public static Text text_2;



    void Start()
    {
        text_2 = GameObject.FindGameObjectWithTag("Text_2").GetComponent<Text>();
        
        HideObject();
    }



    void Update()
    {

        switch (change_text_1.shouldHide_1)
        {

            case true:
                
                Checking();
                if (check_2 == false)
                    HideObject();
                 
                break;
            
        }


    }
   
    public void HideObject()
    {
        text_2.enabled = false;
    }
    void OpenObject()
    {
        text_2.enabled = true;
    }
    void Checking()
    {
        switch (check_2)
        {
            case true:
                OpenObject();
                break;
        }
    }
}
