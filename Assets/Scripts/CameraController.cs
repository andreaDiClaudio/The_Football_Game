using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //References
    [Header("References")]
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public Transform ballTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial camera position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = ballTransform.position + offset;
    }

    public void ResetCameraPosition()
    {
        // Reset the camera position and rotation to the initial values
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
