using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBoundary : MonoBehaviour
{

    [Header("Player Settings")]
    [Tooltip("The DeathAndRespawn component that handles player death and respawn")]
    public DeathAndRespawn deathAndRespawn;

    [Tooltip("The Player component that controls the player's movement")]
    public Player player;

    [Tooltip("The game object that represents the player in the scene")]
    public GameObject playerGameObject;

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            deathAndRespawn.Die();
        }
    }
}