using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public DeathAndRespawn deathAndRespawn;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            deathAndRespawn.Die();
        }
    }
}
