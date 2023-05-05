using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to player")]
    public Player player;
    [Tooltip("Strength used to kick the ball")]
    public float kickPower;
    [Tooltip("Reference to rigidBody of the ball")]

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (other.gameObject.layer == 6)
        {
            var deltaPosition = rigidbody.transform.position - player.characterController.transform.position;

            deltaPosition.y = 0;

            var forward = deltaPosition.normalized;

            rigidbody.AddForce(forward * kickPower, ForceMode.Impulse); //TODO Improve thhis like try to multiply the kickpower with the player speed.
        }
    }
}
