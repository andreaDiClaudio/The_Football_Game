using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    public int deathCounter = 0;
    public DeathAndRespawn deathAndRespawn;
    public static bool isDead = false;

    //Detects if the ball touches the box collider for the game boundaries.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isDead = true;
            deathAndRespawn.Die();
            deathCounter++;
            if (deathCounter == 3)
            {
                //TODO fail screen
                Debug.Log("GAME OVER");
            }
        }
    }
}
