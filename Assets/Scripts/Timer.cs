using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Header("Timer Settings")]
    [Tooltip("The TMP text object that displays the timer")]
    public TMP_Text clockText;

    // The start time of the timer
    static float startTime;

    // Whether the timer is currently active or not
    public static bool isTimerActive = false;

    // The elapsed time since the timer started
    static float elapsedTime;

    [Header("Death and Respawn Settings")]
    [Tooltip("The DeathAndRespawn component that handles player death and respawn")]
    public DeathAndRespawn deathAndRespawn;

    public string seconds;

    public string minutes;

    [Header("Audio Settings")]
    [Tooltip("The audio source that plays a sound effect when the timer reaches 0")]
    public AudioSource audioSource;

    [Tooltip("The sound effect that plays when the timer reaches 0")]
    public AudioClip audioClip;
    void Update()
    {
        // Check if the timer is active
        if (isTimerActive)
        {
            // Check if less than 5 seconds remain
            if (elapsedTime < 5f)
            {
                // Set the color of the clock text to red
                clockText.color = Color.red;

                // Play a sound effect if the integer portion of the elapsed time changes
                if (Mathf.FloorToInt(elapsedTime) != Mathf.FloorToInt(elapsedTime + Time.deltaTime))
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                }
            }
            else
            {
                // Set the color of the clock text to white
                clockText.color = Color.white;
            }

            // Calculate the remaining time
            elapsedTime = startTime - Time.time;

            // Check if the timer has reached zero
            if (elapsedTime < 0f)
            {
                // Stop the timer and trigger the death and respawn function
                elapsedTime = 0f;
                isTimerActive = false;
                deathAndRespawn.Die();
            }

            // Calculate the minutes and seconds remaining in the timer
            minutes = Mathf.FloorToInt(elapsedTime / 60f).ToString("00");
            seconds = (elapsedTime % 60f).ToString("F2");

            // Build the timer text string in the format MM:SS
            string timerText = minutes + ":" + seconds;

            // Update the text of the clock object with the timer text string
            clockText.text = timerText;
        }
    }

    public static void StartTimer()
    {
        isTimerActive = true;
        elapsedTime = 45f;
        startTime = Time.time + elapsedTime;
    }

    public static void StopTimer()
    {
        isTimerActive = false;
    }
}
