using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKickedSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void PlayBallKicked()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
