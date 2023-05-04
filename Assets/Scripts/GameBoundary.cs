using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    public int deathCounter = 0;
    public DeathAndRespawn deathAndRespawn;
    public static bool isDead = false;
    public GameObject gameOverScreen;
    public Player player;
    public GameObject playerGameObject;

    public GameObject ball;
    public Rigidbody ballRigidBody;

    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            deathCounter++;
            if (deathCounter == 3)
            {
                isDead = true;
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
            }
            else
            {
                isDead = true;
                deathAndRespawn.Die();
            }
        }
    }
}
