using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath 
{
    static public float Square(float value)
    {
        return value * value;
    }


    static public float Distance(Coords point1, Coords point2)
    {
        float x = point2.x - point1.x;
        float y = point2.y - point1.y;
        float z = point2.z - point1.z;

        return Mathf.Sqrt(Square(x) + Square(y) + Square(z));
    }

    static public Coords GetNormal(Coords vector)
    {
        float distance = Distance(new Coords(0, 0, 0), vector);
        vector.x /= distance;
        vector.y /= distance;
        vector.z /= distance;

        return vector;  
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        // Dot(vector1, vector2) > 0       angle < 90
        // Dot(vector1, vector2) = 0       angle = 90
        // Dot(vector1, vector2) < 0       angle > 90

        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector1.z;
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        // Independent to order 
        float denominator = Dot(vector1, vector2);
        // Distance is always positive because of pitagoras
        // Also independent to order
        float numerator = Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2);

        return Mathf.Acos(denominator / numerator); // radians. For degree * 180/Mathf.PI;
    }

    static public Coords Rotate(Coords vector, float angle) // in radians (because it will come from angle method)
    {
        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }
}
