using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDelay : MonoBehaviour
{
    public GameObject countdownGameObject;
    public TMP_Text countdownText;
    public float timeLeft = 3.0f;
    public GameObject hud;
    //public PauseController pauseController;
    public void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(StartLevelDelay());
        StartCoroutine(Count());
    }

    public IEnumerator StartLevelDelay()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }
    public IEnumerator Count()
    {
        while (timeLeft > 0)
        {
            //TODO disable the escape to go to menu while counting down. //TODO MORE COMMENTS
            hud.SetActive(false);
            countdownText.text = timeLeft.ToString();
            yield return new WaitForSecondsRealtime(1.0f);
            timeLeft--;
        }
        hud.SetActive(true);
        countdownGameObject.SetActive(false);
        Timer.startTimer();
    }
}