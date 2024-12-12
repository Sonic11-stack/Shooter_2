using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundExplosion : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private ExplosionGrenade explosionGrenade;

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource не найден на объекте!");
            return;
        }

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

      
        if (explosionGrenade == null)
        {
            explosionGrenade = GetComponent<ExplosionGrenade>();
            if (explosionGrenade == null)
            {
                Debug.LogError("ExplosionGrenade не найден! Убедитесь, что компонент присвоен.");
            }
        }
    }

    private void Update()
    {
        if (explosionGrenade != null && explosionGrenade.explodeGrenade == true)
        {
            PlayFirstMusic();
            explosionGrenade.explodeGrenade = false;
        }
    }

    public void PlayFirstMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
