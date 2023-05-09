using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDelay : MonoBehaviour
{
    [Header("UI Settings")]
    [Tooltip("The game object that represents the countdown UI element")]
    public GameObject countdownGameObject;

    [Tooltip("The text component that displays the countdown timer")]
    public TMP_Text countdownText;

    [Tooltip("The initial time left for the countdown")]
    public float timeLeft = 3.0f;

    [Tooltip("The game object that represents the HUD UI element")]
    public GameObject hud;

    [Header("Audio Settings")]
    [Tooltip("The CrowdCheeringFailureSoundEffect component that plays a crowd booing sound effect when the player fails")]
    public CrowdCheeringFailureSoundEffect crowdCheeringFailureSoundEffect;

    [Tooltip("The Pause component that controls pausing and resuming the game")]
    public Pause pause;

    public void Start()
    {
        // Deactivate the pause menu game object
        pause.gameObject.SetActive(false);
        // Set the time scale to 0 to pause the game
        Time.timeScale = 0;
        // Start the level after a delay of 3 seconds
        StartCoroutine(StartLevelDelay());
        // Start the countdown coroutine
        StartCoroutine(Count());
    }

    // Coroutine that starts the level after a delay of 3 seconds
    public IEnumerator StartLevelDelay()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
    }

    // Coroutine that manages the countdown timer
    public IEnumerator Count()
    {
        // If the timeLeft variable is 3, stop the crowd booing sound effect
        if (timeLeft == 3)
        {
            crowdCheeringFailureSoundEffect.StopBooing();
        }

        while (timeLeft > 0)
        {
            // Disable the pause menu and HUD game objects
            pause.enabled = false;
            hud.SetActive(false);
            // Update the countdown text with the remaining time
            countdownText.text = timeLeft.ToString();
            // Wait for 1 second using real time (i.e. not affected by time scale)
            yield return new WaitForSecondsRealtime(1.0f);
            // Decrement the timeLeft variable
            timeLeft--;
        }

        // Enable the pause menu and HUD game objects
        pause.enabled = true;
        hud.SetActive(true);
        // Deactivate the countdown UI element game object
        countdownGameObject.SetActive(false);
        // Activate the pause menu game object
        pause.gameObject.SetActive(true);
        // Start the timer
        Timer.StartTimer();
    }
}