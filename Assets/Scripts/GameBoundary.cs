using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBoundary : MonoBehaviour
{
    public DeathAndRespawn deathAndRespawn;

    public Player player;
    public GameObject playerGameObject;

    public GameObject ball;
    public Rigidbody ballRigidBody;

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            deathAndRespawn.Die();
        }
    }
}