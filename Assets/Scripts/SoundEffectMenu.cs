using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectMenu : MonoBehaviour
{
    public static AudioSource audioSource;
    public AudioClip buttonSfx;

    public void ButtonSfx()
    {
        audioSource.clip = buttonSfx;
        audioSource.Play();
    }
}
