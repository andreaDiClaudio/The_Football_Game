using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public new Transform transform;
    public CharacterController characterController;
    public GameObject player;
    //public LevelDelay levelDelay;

    //Movement
    [Header("Movement")]
    [Tooltip("Unites moved per second at maximum speed")]
    public float movementSpeed = 24; //maximum speed at which player us capwable of moving per seconf

    [Tooltip("Time, in second, to reach maximum speed")]
    public float timeToMaxSpeed = .26f; //Time, in second, taken to build up the maximum speed

    //Property
    private float VelocityGainedPerSecond => movementSpeed / timeToMaxSpeed;

    [Tooltip("TIme, in seconds, to go from maximum speed to stationary")]
    public float timeToLoseMaxSpeed = .2f; //Time, in seconds, taken to go from the maximum speed to stationary when you stop holding down the movement keys

    //Property
    private float VelocityLossPerSecond { get { return movementSpeed / timeToLoseMaxSpeed; } }

    [Tooltip("Multiplier for momentum when attempting to move in a direction opposite to current traveling direction")]
    public float reverseMomentumMultiplier = 2.2f;
    public static Vector3 movementVelocity = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    /*MOVEMENT*/
    void Movement()
    {

        // Sorting the Z dimension first..
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (movementVelocity.z >= 0)
            {
                // Forwards
                movementVelocity.z += VelocityGainedPerSecond * Time.deltaTime;
                movementVelocity.z = Mathf.Min(movementSpeed, movementVelocity.z);
            }
            else
            {
                // Reverse forwards
                movementVelocity.z += VelocityGainedPerSecond * reverseMomentumMultiplier * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (movementVelocity.z <= 0)
            {
                // Backwards
                movementVelocity.z -= VelocityGainedPerSecond * Time.deltaTime;
                movementVelocity.z = Mathf.Max(-movementSpeed, movementVelocity.z);
            }
            else
            {
                // Reverse backwards
                movementVelocity.z -= VelocityGainedPerSecond * reverseMomentumMultiplier * Time.deltaTime;
                //movementVelocity.z = Mathf.Max(0, movementVelocity.z);
            }
        }
        else
        {
            // Slow down 
            if (movementVelocity.z > 0)
            {
                // From forwards
                movementVelocity.z -= VelocityLossPerSecond * Time.deltaTime;
                movementVelocity.z = Mathf.Max(0, movementVelocity.z);
            }
            else if (movementVelocity.z < 0)
            {
                // From backwards
                movementVelocity.z += VelocityLossPerSecond * Time.deltaTime;
                movementVelocity.z = Mathf.Min(0, movementVelocity.z);
            }

        }


        // Same as above, but in the left/right of the X dimension
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (movementVelocity.x >= 0)
            {
                // Right
                movementVelocity.x += VelocityGainedPerSecond * Time.deltaTime;
                movementVelocity.x = Mathf.Min(movementSpeed, movementVelocity.x);
            }
            else
            {
                // Reverse right
                movementVelocity.x += VelocityGainedPerSecond * reverseMomentumMultiplier * Time.deltaTime;
                //movementVelocity.x = Mathf.Min(0, movementVelocity.x);
            }

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (movementVelocity.x <= 0)
            {
                // Left
                movementVelocity.x -= VelocityGainedPerSecond * Time.deltaTime;
                movementVelocity.x = Mathf.Max(-movementSpeed, movementVelocity.x);
            }
            else
            {
                // Break left
                movementVelocity.x -= VelocityGainedPerSecond * reverseMomentumMultiplier * Time.deltaTime;
            }
        }
        else
        {
            // Slow down 
            if (movementVelocity.x > 0)
            {
                // From right
                movementVelocity.x -= VelocityLossPerSecond * Time.deltaTime;
                movementVelocity.x = Mathf.Max(0, movementVelocity.x);
            }
            else if (movementVelocity.x < 0)
            {
                // From left
                movementVelocity.x += VelocityLossPerSecond * Time.deltaTime;
                movementVelocity.x = Mathf.Min(0, movementVelocity.x);
            }

        }

        // No need to move the character controller if no movement registered.
        if (movementVelocity.z != 0 || movementVelocity.x != 0)
        {
            characterController.Move(movementVelocity * Time.deltaTime);
            if (transform is not null)
            {
                var toLookRotation = Quaternion.LookRotation(movementVelocity);
                // Slerp in a slow way from having one rotation to a target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, toLookRotation, .1f);
            }
        }
    }
}
