using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhistleSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip whistleSfx;
    public LevelDelay levelDelay;

    // Update is called once per frame
    void Update()
    {
        if (levelDelay.timeLeft == 1)
        {
            PlayWhistle();
        }
    }

    public void PlayWhistle()
    {
        audioSource.clip = whistleSfx;
        audioSource.Play();
    }

}
