using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Game : MonoBehaviour
{
    
    public static int scene_1;
    void Start()
    {
        
    }

    
    void Update()
    {
     
       
        if (Input.GetKeyDown(KeyCode.F))
        
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            
        }
    }

}
