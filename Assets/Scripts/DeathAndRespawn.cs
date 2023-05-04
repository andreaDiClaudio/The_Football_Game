using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool isBallDead = false;

    [Header("Player")]
    [Tooltip("The player object")]
    public Player player;

    [Tooltip("The game object that represents the player")]
    public GameObject playerGameObject;

    [Tooltip("The transform of the player game object")]
    public Transform playerTransform;

    private Vector3 playerSpawnPoint;
    private Quaternion playerSpawnRotation;
    private bool isPlayerDead = false;

    [Header("Death and Respawn")]
    [Tooltip("The time (in seconds) it takes for the player to respawn after dying")]
    public float respawnTime = 1f;

    //public CameraController cameraController; TODO together with ball position

    int deathCount = 0;

    void Start()
    {
        //Saves the spawn point and spawn rotation of the player
        playerSpawnPoint = player.transform.position;
        playerSpawnRotation = player.transform.rotation;

        //Saves the spawn point of the ball
        ballSpawnPoint = ball.transform.position;
        ballSpawnRotation = ball.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Die();
        }
    }

    public void Die()
    {
        if (!isPlayerDead || !isBallDead)
        {
            /*TIMER*/
            //Clock.StopTimer(); //TODO Implement Timer

            /*PLAYER*/
            isPlayerDead = true;
            //set velocity to 0,0,0
            Player.movementVelocity = Vector3.zero;
            //Disable the component (script)
            player.enabled = false;
            //Disable characterController
            player.characterController.enabled = false;
            //Disable GameObject
            playerGameObject.SetActive(false);

            /*BALL*/
            isBallDead = true;
            //set velocity to 0,0,0
            ballRigidBody.velocity = Vector3.zero;
            //Disable GameObject
            ball.SetActive(false);


            //Invoke: invokes a method after a period of time. First argument is the methodName, second is the time. When you invoke a method you cannot pass any parameter to it.
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    public void Respawn()
    {
        /*PLAYER*/
        isPlayerDead = false;
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

        /*LEVEL DELAY*/
        /*
        //Level Delay to wait three second before actuallt start to play
        levelDelay.hud.SetActive(true);
        levelDelay.timeLeft = 3;
        Time.timeScale = 0;
        StartCoroutine(levelDelay.StartLevelDelay());
        StartCoroutine(levelDelay.Count());

        Clock.startTimer();
        */

        deathCount++;
    }
}
