using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public Player player;
    public float kickPower;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (other.gameObject.layer == 6)
        {
            Debug.Log("Ball collided with player!");
            // By subtracting the two vectors, we get a delta that 
            // 'points' from player towards this object, basically
            // The direction we need to move forwards
            var deltaPosition = rigidbody.transform.position - player.characterController.transform.position;

            // Make sure y is flattened since we do not
            // move up or down
            deltaPosition.y = 0;

            // Make it a unit direction (magnitude of 1)
            var forward = deltaPosition.normalized;

            // Add an impulse forward, using the speed of the player
            rigidbody.AddForce(forward * kickPower, ForceMode.Impulse);

        }
    }
}
