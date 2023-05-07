using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    private bool isMenuVisible = false;
    public AudioSource audioSource;
    public LevelDelay levelDelay;

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
