using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdCheeringFailureSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void PlayBooing()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void StopBooing()
    {
        audioSource.Stop();
    }
}
