using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public DeathAndRespawn deathAndRespawn;
    public void OnTriggerEnter(Collider other)
    {
        //Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (other.gameObject.layer == 6)
        {
            deathAndRespawn.Die();
        }
    }


}
