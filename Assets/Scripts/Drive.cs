using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    float speed = 5f;
    Vector3 direction;
    public GameObject fuel;
    float stoppingDistance = 0.1f;

    private void Start()
    {
        // If direction is declared here, the value of direction wont change each frame
        // this way, direction wont get smaller each frame and the Tank speed will be
        // constant and the tank is going to pass the fuel
        direction = fuel.transform.position - transform.position;
        Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
        direction = dirNormal.ToVector();
        float angle = HolisticMath.Angle(new Coords(transform.up), new Coords(direction)); //* 180.0f/Mathf.PI;
        //Debug.Log("Angle to fuel: " + angle);

        // green axis: transform.up
        // red axis: transform.right
        // blue axis: transform.forward

        Debug.Log("transform.up: " + transform.up);
        Debug.Log("dirNormal: " + dirNormal);

        bool clockwise = false;
        // If this cross product between transform.up and direction to goal is positive, by right hand rule 
        // (going from first parameter to second parameter),
        // that indicates anti-clockwise rotation.
        // If this cross product between transform.up and direction to goal is negative, by right hand rule 
        // (going from first parameter to second parameter),
        // that indicates clockwise rotation.
        if (HolisticMath.Cross(new Coords(transform.up), dirNormal).z < 0)
        {
            clockwise = true;
        }

        Coords newDir = HolisticMath.Rotate(new Coords(0, 1, 0), angle, clockwise);
        transform.up = new Vector3(newDir.x, newDir.y, newDir.z);
        Debug.Log(transform.up);
    }

    void Update()
    {
        // If direction is declared here, the tank deacelerates when is near the fuel
        // This happens because transform.position increases each frame, in this way
        // direction decreaces each frame. 
        // The tank will almost reach the fuel, but never will exactly reach it
        // so, its necessary a stopping condition to stop the tank
        //direction = fuel.transform.position - transform.position;

        if (HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stoppingDistance)
        {

            // multiply by Time.deltaTime ensures a more consistent movement, independent of fps
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}