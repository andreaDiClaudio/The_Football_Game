using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patroller : MonoBehaviour
{
    public Transform[] points;
    int current;
    public float speed;

    void Start()
    {
        current = 0;
        //transform.position = //TODO;
    }

    void Update()
    {
        if (transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }
}
