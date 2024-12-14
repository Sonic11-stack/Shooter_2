using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Open_Main_Game()
    {
        SceneManager.LoadScene("Main_Scene");
        

    }
    public void Close_Game()
    {
        Application.Quit();
    }
    
}
