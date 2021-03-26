using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    float speed = .01f;
    Vector3 direction;
    public GameObject fuel;
    float stoppingDistance = 0.1f;

    private void Start()
    {
        // If direction is declared here, the value of direction wont change each frame
        // this way, direction wont get smaller each frame and the Tank speed will be
        // constant and the tank is going to pass the fuel
        direction = fuel.transform.position - transform.position;
    }

    void Update()
    {
        // If direction is declared here, the tank deacelerates when is near the fuel
        // This happens because transform.position increases each frame, in this way
        // direction decreaces each frame. 
        // The tank will almost reach the fuel, but never will exactly reach it
        // so, its necessary a stopping condition to stop the tank
        //direction = fuel.transform.position - transform.position;

        if (Vector3.Distance(transform.position, fuel.transform.position) > stoppingDistance)
        {
            transform.position += direction * speed;
        }
    }
}