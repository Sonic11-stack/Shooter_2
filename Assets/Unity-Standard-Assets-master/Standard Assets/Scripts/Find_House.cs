using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class Find_House : MonoBehaviour
{
    public bool check_house_1 = false;
    public float delay = 3.0f;
    private float timer = 0.0f;
    public  bool check_3 = false;
    [SerializeField] private Change_Text_2 change_text_2;

    public Text text_3;

    void Start()
    {
        text_3 = GameObject.FindGameObjectWithTag("Text_3").GetComponent<Text>();
        HideObject();
    }

    
    void Update()
    {
        switch (check_house_1)
        {
            case true:
                Pass_Time();
                break;
        }
     }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            switch(change_text_2.check_2)
            {
                case true:
                    OpenObject();
                    check_house_1 = true;
                    change_text_2.check_2 = false;
                    
                    break;
                
            }
            

        }
    }
    void HideObject()
    {
        text_3.enabled = false;
        
    }
   
    void OpenObject()
    {
        text_3.enabled = true;
    }
    void Pass_Time()
    {
        timer += Time.deltaTime;

        if (timer >= delay)
        {
            HideObject();
            check_3 = true;
        }
    }
}
