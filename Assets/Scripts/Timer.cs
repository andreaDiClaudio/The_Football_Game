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

    void Update()
    {
        if (isTimerActive)
        {
            elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString();
            seconds = (elapsedTime % 60).ToString("f2");
            string timerText = minutes + ":" + seconds;
            clockText.text = timerText;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (seconds == "2.00") //WORKING TODO text during countdown to show player time limit. and make the player die.
            {
                Debug.Log("Elapsed time is 2 seconds!");
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
