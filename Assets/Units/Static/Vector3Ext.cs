using UnityEngine;

public static class Vector3Ext
{
    public static float GetX(Vector3 a)
    {
        return a.x;
    }

    public static float GetY(Vector3 a)
    {
        return a.y;
    }

    public static float GetZ(Vector3 a)
    {
        return a.z;
    }

    public static Vector3 FromComponents(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }

    public static Vector3 Add(Vector3 a, Vector3 b)
    {
        return a + b;
    }

    public static Vector3 Subtract(Vector3 a, Vector3 b)
    {
        return a - b;
    }

    public static Vector3 Negate(Vector3 a)
    {
        return -a;
    }

    public static Vector3 Multiply(Vector3 a, float d)
    {
        return a * d;
    }

    public static Vector3 Divide(Vector3 a, float d)
    {
        return a / d;
    }

    public static bool Equal(Vector3 x, Vector3 y)
    {
        return x == y;
    }

    public static bool NotEqual(Vector3 x, Vector3 y)
    {
        return x != y;
    }

    public static float Magnitude(Vector3 a)
    {
        return a.magnitude;
    }

    public static float SqrMagnitude(Vector3 a)
    {
        return a.sqrMagnitude;
    }
}
