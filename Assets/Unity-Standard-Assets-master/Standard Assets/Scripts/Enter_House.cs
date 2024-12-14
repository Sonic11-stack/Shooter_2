using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enter_House : MonoBehaviour
{
    GameObject padlock;
    GameObject image;
    GameObject strip;

    
    [SerializeField] private Count_Of_Keys count_of_keys;

    [SerializeField] private Change_Text_5 change_text_5;

    public bool check_final = false;    
    Text endurance;
    void Start()
    {
        
        padlock = GameObject.FindWithTag("padlock");
        image = GameObject.FindWithTag("image");
        strip = GameObject.FindWithTag("strip");

        endurance = GameObject.FindGameObjectWithTag("endurance").GetComponent<Text>();
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && count_of_keys.count == 5)
        {
            padlock.SetActive(false);
            image.SetActive(false);
            strip.SetActive(false);
            endurance.enabled = false;
            
            check_final = true;
        }



    }
    
}
