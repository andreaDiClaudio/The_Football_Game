using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathAndRespawn : MonoBehaviour
{
    [Header("References")]

    [Header("Ball")]
    [Tooltip("The ball object")]
    public GameObject ball;
    [Tooltip("The ball rigidBody")]
    public Rigidbody ballRigidBody;
    private Vector3 ballSpawnPoint;
    private Quaternion ballSpawnRotation;
    public static bool isBallDead = false;
    public static int deathCounter = 3;

    [Header("Player")]
    [Tooltip("The player object")]
    public Player player;

    [Tooltip("The game object that represents the player")]
    public GameObject playerGameObject;

    [Tooltip("The transform of the player game object")]
    public Transform playerTransform;

    private Vector3 playerSpawnPoint;
    private Quaternion playerSpawnRotation;

    [Header("Death and Respawn")]
    [Tooltip("The time (in seconds) it takes for the player to respawn after dying")]
    public float respawnTime = 1f;
    // The LevelDelay component that controls the delay between attempts
    [Header("Level Settings")]
    [Tooltip("The LevelDelay component that controls the delay between attempts")]
    public LevelDelay levelDelay;

    // The TMP text object that displays the current attempt number
    [Header("UI Settings")]
    [Tooltip("The TMP text object that displays the current attempt number")]
    public TMP_Text attemptText;

    [Header("Audio Settings")]
    [Tooltip("The WhistleSoundEffect component that plays a whistle sound effect")]
    public WhistleSoundEffect whistleSoundEffect;

    [Tooltip("The CrowdCheeringFailureSoundEffect component that plays a crowd cheering sound effect when the player fails")]
    public CrowdCheeringFailureSoundEffect crowdCheeringFailureSoundEffect;

    [Tooltip("The game over screen object")]
    public GameObject gameOverScreen;

    [Tooltip("The Pause component that controls pausing and resuming the game")]
    public Pause pause;
    void Start()
    {
        //Saves the spawn point and spawn rotation of the player
        playerSpawnPoint = player.transform.position;
        playerSpawnRotation = player.transform.rotation;

        //Saves the spawn point of the ball
        ballSpawnPoint = ball.transform.position;
        ballSpawnRotation = ball.transform.rotation;

        gameOverScreen.SetActive(false);

        //obstacleInitialPosition = obstacle.transform.position;
    }

    void Update()
    {
        attemptText.text = $"Attempt: {deathCounter}";
    }

    public void Die()
    {
        pause.enabled = false;
        if (!isBallDead)
        {
            whistleSoundEffect.PlayWhistle();
            crowdCheeringFailureSoundEffect.PlayBooing();

            deathCounter--;
            if (deathCounter == 0)
            {
                gameOverScreen.SetActive(true);
                /*TIMER*/
                Timer.StopTimer();

                /*PLAYER*/
                //set velocity to 0,0,0
                Player.movementVelocity = Vector3.zero;
                //Disable the component (script)
                player.enabled = false;
                //Disable characterController
                player.characterController.enabled = false;
                //Disable GameObject
                playerGameObject.SetActive(false);

                /*BALL*/
                DeathAndRespawn.isBallDead = true;
                //set velocity to 0,0,0
                ballRigidBody.velocity = Vector3.zero;
                //Disable GameObject
                ball.SetActive(false);

                DeathAndRespawn.isBallDead = false;

                deathCounter = 3;
            }
            else
            {

                isBallDead = true;

                /*TIMER*/
                Timer.StopTimer();

                /*PLAYER*/
                //set velocity to 0,0,0
                Player.movementVelocity = Vector3.zero;
                //Disable the component (script)
                player.enabled = false;
                //Disable characterController
                player.characterController.enabled = false;
                //Disable GameObject
                playerGameObject.SetActive(false);

                /*BALL*/
                //set velocity to 0,0,0
                ballRigidBody.velocity = Vector3.zero;
                //Disable GameObject
                ball.SetActive(false);

                //Invoke: invokes a method after a period of time. First argument is the methodName, second is the time. When you invoke a method you cannot pass any parameter to it.
                Invoke(nameof(Respawn), respawnTime);
            }
        }
    }

    public void Respawn()
    {
        /*PLAYER*/
        //Reset Player position
        player.transform.position = playerSpawnPoint;
        //Reset Player Rotation
        playerTransform.rotation = playerSpawnRotation;
        //Enable component (script)
        player.enabled = true;
        //Enable player characterController
        player.characterController.enabled = true;
        //Activate GameObject
        playerGameObject.SetActive(true);
        //cameraController.ResetCameraPosition();

        /*BALL*/
        isBallDead = false;
        //Reset ball position
        ball.transform.position = ballSpawnPoint;
        ball.transform.rotation = ballSpawnRotation;
        //Enable GameObject
        ball.SetActive(true);
        //set velocity and rotation to 0,0,0
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        /*LEVEL DELAY*/
        //Level Delay to wait three second before actuallt start to play
        levelDelay.hud.SetActive(false);
        levelDelay.countdownGameObject.SetActive(true);
        levelDelay.timeLeft = 3;
        Time.timeScale = 0;
        StartCoroutine(levelDelay.StartLevelDelay());
        StartCoroutine(levelDelay.Count());

        /*OBSTACLE*/
        //obstacle.transform.position = obstacleInitialPosition;

        pause.enabled = true;

        Timer.StartTimer();
    }
}
