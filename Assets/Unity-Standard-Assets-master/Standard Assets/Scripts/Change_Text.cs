using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Text : MonoBehaviour
{
    public float delay = 3.0f; 
    private float timer = 0.0f;
    
    public bool shouldHide = false;
    

    public Text text;
   


    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
        
    }

   

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delay && !shouldHide)
        {
            HideObject();
            shouldHide = true;
        }
        
    }

    void HideObject()
    {
        text.enabled = false;
    }

}
