using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCrowdSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip goalCrowdCheering;

    public void PlayGoalCheering()
    {
        audioSource.clip = goalCrowdCheering;
        audioSource.Play();
    }
}
