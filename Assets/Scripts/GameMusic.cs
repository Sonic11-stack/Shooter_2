using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
