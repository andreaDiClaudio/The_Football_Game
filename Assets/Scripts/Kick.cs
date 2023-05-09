using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Reference to player")]
    public Player player;
    [Tooltip("Strength used to kick the ball")]
    public float kickPower;
    [Tooltip("Reference to rigidBody of the ball")]
    public BallKickedSoundEffect ballKickedSoundEffect;

    // Method that is called when a Collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Get the Rigidbody component of the collided object
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        // Check if the collided object is on layer 6 (presumably the ball)
        if (other.gameObject.layer == 6)
        {
            // Play the ball kicked sound effect
            ballKickedSoundEffect.PlayBallKicked();

            // Calculate the difference in position between the rigidbody and the player character
            var deltaPosition = rigidbody.transform.position - player.characterController.transform.position;
            // Set the y component of deltaPosition to 0 to only consider movement in the x-z plane
            deltaPosition.y = 0;
            // Normalize the deltaPosition vector to get a unit vector in the direction of the force to apply
            var forward = deltaPosition.normalized;

            // Check if the rigidbody is not moving
            if (rigidbody.velocity.magnitude == 0)
            {
                // Apply an impulse force to the rigidbody in the forward direction with a scaling factor of kickPower * 1.2
                rigidbody.AddForce(forward * (kickPower * 1.2f), ForceMode.Impulse);
            }

            // Apply an impulse force to the rigidbody in the forward direction with a scaling factor of kickPower * 1.4
            rigidbody.AddForce(forward * (kickPower * 1.4f), ForceMode.Impulse);
        }
    }
}
