using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text clockText;
    static float startTime;
    public static bool isTimerActive = false;
    static float elapsedTime;
    public DeathAndRespawn deathAndRespawn;
    public string seconds;
    public string minutes;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Update()
    {
        if (isTimerActive)
        {
            if (elapsedTime < 5f)
            {
                clockText.color = Color.red;

                if (Mathf.FloorToInt(elapsedTime) != Mathf.FloorToInt(elapsedTime + Time.deltaTime))
                {
                    audioSource.clip = audioClip;
                    audioSource.Play();
                }
            }
            else
            {
                clockText.color = Color.white;
            }

            elapsedTime = startTime - Time.time;
            if (elapsedTime < 0f)
            {
                elapsedTime = 0f;
                isTimerActive = false;
                deathAndRespawn.Die();
            }

            minutes = Mathf.FloorToInt(elapsedTime / 60f).ToString("00");
            seconds = Mathf.FloorToInt(elapsedTime % 60f).ToString("00");

            string timerText = minutes + ":" + seconds;
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
