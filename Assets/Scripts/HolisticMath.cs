using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath 
{
    static public Coords GetNormal(Coords vector)
    {
        float distance = Distance(new Coords(0, 0, 0), vector);
        vector.x /= distance;
        vector.y /= distance;
        vector.z /= distance;

        return vector;  
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float x = point2.x - point1.x;
        float y = point2.y - point1.y;
        float z = point2.z - point1.z;

        return Mathf.Sqrt(Square(x) + Square(y) + Square(z));
    }

    static public float Square(float value)
    {
        return value * value;
    }
}
