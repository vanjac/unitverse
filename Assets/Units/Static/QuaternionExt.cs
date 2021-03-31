using UnityEngine;

public static class QuaternionExt
{
    public static float GetX(Quaternion q)
    {
        return q.x;
    }

    public static float GetY(Quaternion q)
    {
        return q.y;
    }

    public static float GetZ(Quaternion q)
    {
        return q.z;
    }

    public static float GetW(Quaternion q)
    {
        return q.w;
    }

    public static Quaternion FromComponents(float x, float y, float z, float w)
    {
        return new Quaternion(x, y, z, w);
    }

    public static Quaternion Multiply(Quaternion a, Quaternion b)
    {
        return a * b;
    }

    public static Vector3 Rotate(Quaternion rotation, Vector3 point)
    {
        return rotation * point;
    }

    public static bool Equal(Quaternion x, Quaternion y)
    {
        return x == y;
    }

    public static bool NotEqual(Quaternion x, Quaternion y)
    {
        return x != y;
    }

    public static Vector3 EulerAngles(Quaternion q)
    {
        return q.eulerAngles;
    }
}
