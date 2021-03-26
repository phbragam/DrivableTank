﻿using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    Vector2 dir = new Vector2(0.1f, 0.1f);

    void Update()
    {
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
        {
        position.x += dir.x;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
        position.x -= dir.x;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += dir.y;
        }

         if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= dir.y;
        }

        transform.position = position;
    }
}