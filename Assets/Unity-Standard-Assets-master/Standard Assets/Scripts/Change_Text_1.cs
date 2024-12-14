using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;

public class Change_Text_1 : MonoBehaviour
{
    public float delay = 3.0f;
    private float timer_1 = 0.0f;
    public  bool shouldHide_1 = false;
    public bool check_1 = true;
    [SerializeField] private Change_Text change_text;

    public Text text_1;



    void Start()
    {
        text_1 = GameObject.FindGameObjectWithTag("Text_1").GetComponent<Text>();
        HideObject();
        
    }


    
    void Update()
    {
        
        switch (change_text.shouldHide)
        {
            
            case true:
                
                Checking();
                
                timer_1 += Time.deltaTime;

                if (timer_1 >= delay && !shouldHide_1)
                {
                    check_1 = false;
                    HideObject();
                    shouldHide_1 = true;
                    
                }
                
                
               
                break;
        }


        
    }
    void HideObject()
    {
        text_1.enabled = false;
    }
    
    void OpenObject()
    {
        text_1.enabled = true;
    }
    void Checking()
    {
        switch(check_1)
        {
            case true:
                OpenObject();
                break;
        }
    }
}