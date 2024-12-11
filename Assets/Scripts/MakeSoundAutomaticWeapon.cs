using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSoundAutomaticWeapon : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip audioClip_1;
    [SerializeField] private AudioSource audioSource_1;

    public bool isShooting = false;

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            audioSource = audioSources[0];
            audioSource_1 = audioSources[1];

        }

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        if (audioClip_1 != null)
        {
            audioSource_1.clip = audioClip_1;
        }
    }

    public void PlayFirstMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void PlaySecondMusic()
    {
        if (!audioSource_1.isPlaying)
        {
            audioSource_1.Play();
        }
    }
    public void StopShootingMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.loop = false; // ��������� ������������
            audioSource.Stop(); // ������������� ���������������
        }
    }
}