using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    public DeathAndRespawn deathAndRespawn;
    void Start()
    {

    }

    void Update()
    {

    }

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            deathAndRespawn.Die();
            //TODO fail screen
        }
    }
}
