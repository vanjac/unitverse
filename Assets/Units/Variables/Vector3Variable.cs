using UnityEngine;

[AddComponentMenu("Units/Variables/Vector 3 Variable")]
public class Vector3Variable : Variable<Vector3>
{
    public float X
    {
        get { return Value.x; }
        set { Value = MyBox.MyVectors.SetX(Value, value); }
    }

    public float Y
    {
        get { return Value.y; }
        set { Value = MyBox.MyVectors.SetY(Value, value); }
    }

    public float Z
    {
        get { return Value.z; }
        set { Value = MyBox.MyVectors.SetZ(Value, value); }
    }

    public Vector3 Add(Vector3 a)
    {
        Value += a;
        return Value;
    }

    public Vector3 Subtract(Vector3 a)
    {
        Value -= a;
        return Value;
    }

    public Vector3 Multiply(float a)
    {
        Value *= a;
        return Value;
    }

    public Vector3 Divide(float a)
    {
        Value /= a;
        return Value;
    }

    public bool Equal(Vector3 a)
    {
        return Value == a;
    }

    public bool NotEqual(Vector3 a)
    {
        return Value != a;
    }

    public Vector3 Normalize()
    {
        Value = Value.normalized;
        return Value;
    }

    public float Magnitude()
    {
        return Value.magnitude;
    }

    public float SqrMagnitude()
    {
        return Value.sqrMagnitude;
    }
}
