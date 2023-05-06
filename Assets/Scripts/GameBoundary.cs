using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBoundary : MonoBehaviour
{
    public int deathCounter = 3;
    public DeathAndRespawn deathAndRespawn;
    public GameObject gameOverScreen;
    public Player player;
    public GameObject playerGameObject;

    public GameObject ball;
    public Rigidbody ballRigidBody;
    public WhistleSoundEffect whistleSoundEffect;
    public CrowdCheeringFailureSoundEffect crowdCheeringFailureSoundEffect;
    public TMP_Text attemptText;

    void Start()
    {
        gameOverScreen.SetActive(false);
        deathCounter = 3;
    }

    void Update()
    {
        attemptText.text = $"Attempt: {deathCounter}";
    }

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
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
            }
            else
            {
                deathAndRespawn.Die();
            }
        }
    }
}