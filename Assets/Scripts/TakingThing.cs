using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingThing : MonoBehaviour
{

    [SerializeField] private AudioClip audioClip;
    [SerializeField]private AudioSource audioSource;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
    }

    private void Update()
    {
        
    }

    public void PlayThingMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
