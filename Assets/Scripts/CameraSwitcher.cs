using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    public Camera mainCamera;
    public Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        playerCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            mainCamera.enabled = !mainCamera.enabled;
            playerCamera.enabled = !playerCamera.enabled;
        }
    }
}
