using UnityEngine;

[AddComponentMenu("Units/Variables/Quaternion Variable")]
public class QuaternionVariable : Variable<Quaternion>
{
    public float X
    {
        get { return Value.x; }
        set { Value = new Quaternion(value, Value.y, Value.z, Value.w); }
    }

    public float Y
    {
        get { return Value.y; }
        set { Value = new Quaternion(Value.x, value, Value.z, Value.w); }
    }

    public float Z
    {
        get { return Value.z; }
        set { Value = new Quaternion(Value.x, Value.y, value, Value.w); }
    }

    public float W
    {
        get { return Value.z; }
        set { Value = new Quaternion(Value.x, Value.y, Value.z, value); }
    }

    public Quaternion Multiply(Quaternion a)
    {
        Value *= a;
        return Value;
    }

    public Vector3 Rotate(Vector3 point)
    {
        return Value * point;
    }

    public bool Equal(Quaternion a)
    {
        return Value == a;
    }

    public bool NotEqual(Quaternion a)
    {
        return Value != a;
    }

    public Vector3 EulerAngles()
    {
        return Value.eulerAngles;
    }
}
