using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streaker : MonoBehaviour
{
    public GameObject streaker;

    [Header("Points to Move Between")]
    [Tooltip("An array of transform objects that represent the points to move the object between.")]
    public Transform[] points;


    [SerializeField]
    [Header("Movement Settings")]
    [Tooltip("The speed at which the object moves between points.")]
    public float speed;

    // The current point in the array that the object is moving towards 
    int current;
    public bool isTriggered = false;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        // Set the current point to the first point in the array
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            // If the object's current position is not the same as the current point's position
            if (transform.position != points[current].position)
            {
                // Move the object towards the current point at a speed of speed * Time.deltaTime
                transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            }
            else
            {
                // Set the current point to the next point in the array (wrapping around to the beginning if necessary)
                current = (current + 1) % points.Length;

                //Deactivates the streaker when reaches the other side of the pitch
                if (current == 0)
                {
                    streaker.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            int randomNumber = Random.Range(0, 11);
            if (randomNumber == 5)
            {
                isTriggered = true;
                audioSource.clip = audioClip;
                audioSource.Play();
            }
        }
    }
}
