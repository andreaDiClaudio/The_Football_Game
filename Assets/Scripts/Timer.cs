using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text clockText;
    static float startTime;
    public static bool isTimerActive = false;
    static float elapsedTime;

    void Start()
    {
    }

    void Update()
    {
        if (isTimerActive)
        {
            elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString();
            string seconds = (elapsedTime % 60).ToString("f2");
            string timerText = minutes + ":" + seconds;
            clockText.text = timerText;
        }
    }

    public static void startTimer()
    {
        isTimerActive = true;
        elapsedTime = 0;
        startTime = Time.time;
        GameBoundary.isDead = false;
    }

    public static void StopTimer()
    {
        isTimerActive = false;
    }
}
