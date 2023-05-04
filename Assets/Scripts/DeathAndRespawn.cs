using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAndRespawn : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The player object")]
    public Player player;
    [Tooltip("The game object that represents the player")]
    public GameObject playerGameObject;

    [Tooltip("The transform of the player game object")]
    public Transform playerTransform;
    [Header("Death and Respawn")]

    [Tooltip("The time (in seconds) it takes for the player to respawn after dying")]
    public float respawnTime = 1f;

    private Vector3 spawnPoint;
    private Quaternion spawnRotation;

    private bool isDead = false;

    //public CameraController cameraController; TODO together with ball position

    int deathCount = 0;

    void Start()
    {
        //Saves the spawn point and spawn rotation of the player
        spawnPoint = player.transform.position;
        spawnRotation = player.transform.rotation;
        //TODO Saves the spawn point of the ball
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
        if (!isDead)
        {
            //Clock.StopTimer(); //TODO Implement Timer
            isDead = true;
            //set velocity to 0,0,0
            Player.movementVelocity = Vector3.zero;
            //disable the component (script)
            enabled = false;
            //disable characterController
            player.characterController.enabled = false;
            //Disable GameObject
            playerGameObject.SetActive(false);
            //Invoke: invokes a method after a period of time. First argument is the methodName, second is the time. When you invoke a method you cannot pass any parameter to it.
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    public void Respawn()
    {
        /*PLAYER*/
        isDead = false;
        //Reset Player position
        player.transform.position = spawnPoint;
        //Reset Player Rotation
        playerTransform.rotation = spawnRotation;
        //Enable component (script)
        enabled = true;
        //Enable player characterController
        player.characterController.enabled = true;
        //Activate GameObject
        playerGameObject.SetActive(true);
        //cameraController.ResetCameraPosition();

        /*BALL*/
        //TODO 

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
