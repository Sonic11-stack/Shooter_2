using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundExplosion : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
   
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }
    }

    public void PlayFirstMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
