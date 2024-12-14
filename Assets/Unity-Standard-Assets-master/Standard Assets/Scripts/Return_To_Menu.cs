using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class Return_To_Menu : MonoBehaviour
{
   
    public static bool check_return = false;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void Return_Menu()
    {
        
       
        
            SceneManager.LoadScene("Menu");
           
    }
    public void Return_Menu_1()
    {
        SceneManager.LoadScene("Menu");
    }
}
