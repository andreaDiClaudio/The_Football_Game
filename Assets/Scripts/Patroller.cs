using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patroller : MonoBehaviour
{
    [SerializeField]
    [Header("Points to Move Between")]
    [Tooltip("An array of transform objects that represent the points to move the object between.")]
    public Transform[] points;

    [SerializeField]
    [Header("Movement Settings")]
    [Tooltip("The speed at which the object moves between points.")]
    public float speed;

    // The current point in the array that the object is moving towards 
    int current;

    // Start is called before the first frame update
    void Start()
    {
        // Set the current point to the first point in the array
        current = 0;
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}