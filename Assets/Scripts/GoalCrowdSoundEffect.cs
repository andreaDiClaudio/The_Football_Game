using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCrowdSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip goalCrowdCheering;

    //TODO Audio when player scores (not here this is just reminder)

    public void PlayGoalCheering()
    {
        audioSource.clip = goalCrowdCheering;
        audioSource.Play();
    }
}
