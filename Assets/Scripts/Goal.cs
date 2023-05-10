using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Goal : MonoBehaviour
{
    [Header("References")]

    [Header("Ball")]
    [Tooltip("The ball object")]
    public GameObject ball;
    [Tooltip("The ball rigidBody")]
    public Rigidbody ballRigidBody;

    [Header("Player")]
    [Tooltip("The player object")]
    public Player player;
    // The game over screen object
    [Header("UI Settings")]
    [Tooltip("The game over screen object")]
    public GameObject winScreen;

    [Tooltip("A static flag that indicates whether the player has scored a goal")]
    public static bool isGoal = false;

    [Tooltip("The Pause component that controls pausing and resuming the game")]
    public Pause pause;

    [Header("Audio Settings")]
    [Tooltip("The GoalCrowdSoundEffect component that plays a crowd cheering sound effect when the player scores a goal")]
    public GoalCrowdSoundEffect goalCrowdSoundEffect;

    [Header("Gameplay Settings")]
    [Tooltip("The Timer component that tracks the time elapsed during gameplay")]
    public Timer timer;

    void Start()
    {
        winScreen.SetActive(false);
        isGoal = false;
    }

    //Detects if the ball touches the box collider for the goal
    private void OnTriggerEnter(Collider other)
    {
        //GameObject goal = gameObject;
        if (other.CompareTag("Ball"))
        {
            goalCrowdSoundEffect.PlayGoalCheering();
            Win();

            // Take the time and save it in a variable
            string secondsLeft = timer.seconds;
            float secondsLeftToFloat = float.Parse(secondsLeft);
            float timeTaken = 45f - secondsLeftToFloat;

            // Convert the time taken to a string with two decimal places
            string stringTimeTaken = timeTaken.ToString("F2");

            // Get the previous score from a local variable
            int levelIndex = SceneManager.GetActiveScene().buildIndex - 1;

            // The new score is better than the previous one, so update the scoreboard and save the new score
            PlayerPrefs.SetFloat("Level" + levelIndex.ToString() + "Score", timeTaken);
            MainMenu.UpdateScoreboard(levelIndex, stringTimeTaken);
        }
    }

    public void Win()
    {
        pause.enabled = false;

        /*TIMER*/
        Timer.StopTimer();

        /*PLAYER*/
        //set velocity to 0,0,0
        Player.movementVelocity = Vector3.zero;
        //Disable the component (script)
        player.enabled = false;
        //Disable characterController
        player.characterController.enabled = false;

        /*BALL*/
        //set velocity and rotation to 0,0,0
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        ball.SetActive(false);

        //Shows Win hud
        winScreen.SetActive(true);

        //Progression
        ProgressionManager.UnlockLevel(SceneManager.GetActiveScene().buildIndex);

        //Reset Lifes
        DeathAndRespawn.deathCounter = 3;

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
