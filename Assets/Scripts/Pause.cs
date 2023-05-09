using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [Header("Menu Settings")]
    [Tooltip("The GameObject that represents the menu.")]
    public GameObject menu;

    [Header("Audio Settings")]
    [Tooltip("The AudioSource component used for audio playback.")]
    public AudioSource audioSource;

    // Flag indicating whether the menu is currently visible
    private bool isMenuVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {

            if (!Goal.isGoal || !DeathAndRespawn.isBallDead)
            {
                if (!isMenuVisible)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }

            }

        }
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Pause
    public void PauseGame()
    {
        isMenuVisible = true;
        menu.SetActive(true);
        //Freeze all; pause every object that is time-based.
        Time.timeScale = 0;
        //Pauses the audio
        audioSource.Pause();
    }

    //Resume from pause
    public void ResumeGame()
    {
        isMenuVisible = false;
        menu.SetActive(false);
        Time.timeScale = 1; //Remove freeze; unpause every object that is time-based.
        audioSource.Play();
    }
}
