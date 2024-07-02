using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip shootingSound;
    public AudioClip collectionSound;
    public AudioClip victorySound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShootingSound()
    {
        audioSource.PlayOneShot(shootingSound);
    }

    public void PlayCollectionSound()
    {
        audioSource.PlayOneShot(collectionSound);
    }

    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victorySound);
    }
}
