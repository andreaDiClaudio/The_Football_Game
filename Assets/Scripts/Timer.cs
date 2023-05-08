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

    void Update()
    {
        if (isTimerActive)
        {
            elapsedTime = Time.time - startTime;
            minutes = ((int)elapsedTime / 60).ToString();
            seconds = (elapsedTime % 60).ToString("f2");
            string timerText = minutes + ":" + seconds;
            clockText.text = timerText;
        }
        if (minutes == "1")
        {
            Debug.Log(minutes);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (seconds == "45.00")
            {
                deathAndRespawn.Die();
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)

        {
            if (minutes == "1")
            {
                deathAndRespawn.Die();
            }
        }
    }

    public static void startTimer()
    {
        isTimerActive = true;
        elapsedTime = 0;
        startTime = Time.time;
    }

    public static void StopTimer()
    {
        isTimerActive = false;
    }
}
