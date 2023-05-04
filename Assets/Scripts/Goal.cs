using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //Detects if the ball touches the box collider for the goal
    private void OnTriggerEnter(Collider other)
    {
        //GameObject goal = gameObject;
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Goal");
        }
    }
}
