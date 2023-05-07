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

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (other.gameObject.layer == 6)
        {
            ballKickedSoundEffect.PlayBallKicked();

            var deltaPosition = rigidbody.transform.position - player.characterController.transform.position;

            deltaPosition.y = 0;

            var forward = deltaPosition.normalized;
            if (rigidbody.velocity.magnitude == 0)
            {
                rigidbody.AddForce(forward * (kickPower * 1.2f), ForceMode.Impulse);
            }
            rigidbody.AddForce(forward * (kickPower * 1.4f), ForceMode.Impulse);
        }
    }
}
