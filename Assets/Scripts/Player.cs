using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //References
    [Header("References")]
    public new Transform transform;
    //public Transform modelTransform;
    public CharacterController characterController;
    //public CameraPositionController cameraController;
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

    private Vector3 movementVelocity = Vector3.zero;

    //Death and Respawn
    [Header("Death and Raspawning")]
    [Tooltip("How Long after the player's death, ins econds, before they are respwaned?")]
    public float respawnTime = 1f;

    //private bool isDead = false;

    private Vector3 spawnPoint;
    private Quaternion spawnRotation;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = player.transform.position;
        spawnRotation = player.transform.rotation;

        //cameraController = GameObject.Find("Main Camera").GetComponent<CameraPositionController>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKey(KeyCode.T))
        {
            //Die();
        }
    }
    /*
        public void Die()
        {
            if (!isDead)
            {
                Clock.StopTimer();
                isDead = true;
                movementVelocity = Vector3.zero; //set velocity to 0,0,0
                enabled = false; //disable the component (script)
                characterController.enabled = false; //disable characterController
                player.SetActive(false); //Disable GameObject
                //Invoke: invokes a method after a period of time. First argument is the methodName, second is the time.
                //When you invoke a method you cannot pass any parameter to it.
                Invoke(nameof(Respawn), respawnTime);
            }
        }

        public void Respawn()
        {
            isDead = false;
            player.transform.position = spawnPoint;
            modelTransform.rotation = spawnRotation;
            enabled = true;
            characterController.enabled = true;
            player.SetActive(true);
            cameraController.ResetCameraPosition();
            DeathController.deathCount++;

            //Level Delay to wait three second before actuallt start to play
            levelDelay.hud.SetActive(true);
            levelDelay.timeLeft = 3;
            Time.timeScale = 0;
            StartCoroutine(levelDelay.StartLevelDelay());
            StartCoroutine(levelDelay.Count());

            Clock.startTimer();

        }
    */
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
