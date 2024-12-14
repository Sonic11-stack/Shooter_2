using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreamerActive : MonoBehaviour {
	public GameObject monstr;

    GameObject image;
    GameObject strip;

    

    Text endurance;

    [SerializeField] private Change_Text_5 change_text_5;

    

    
    void Start()
    {
        image = GameObject.FindWithTag("image");
        strip = GameObject.FindWithTag("strip");

        endurance = GameObject.FindGameObjectWithTag("endurance").GetComponent<Text>();

        
    }
    void  OnTriggerStay ( Collider other  ){
        if (other.tag == "Player")
        {
            monstr.active = true;
            image.SetActive(false);
            strip.SetActive(false);
            endurance.enabled = false;
            


        }
	}
}