using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Camera initial position")]
    private Vector3 initialPosition;
    [Header("Camera rotation initial position")]
    private Quaternion initialRotation;
    [Header("Reference to ball")]
    public Transform playerTransform;
    [Header("Distance of the camera from the ball")]
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial camera position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    //Called once per frame, after all the Update() functions have been called.
    void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }

    // Reset the camera position and rotation to the initial values
    public void ResetCameraPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
