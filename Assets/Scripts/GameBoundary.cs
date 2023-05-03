using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject goal = gameObject;
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Out of Boundaries");
        }
    }
}
