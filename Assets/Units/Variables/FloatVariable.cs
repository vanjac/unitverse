using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_compare
[AddComponentMenu("Units/Variables/Float Variable")]
public class FloatVariable : Variable<float>
{
    public float Add(float a)
    {
        Value += a;
        return Value;
    }

    public float Subtract(float a)
    {
        Value -= a;
        return Value;
    }

    public float Multiply(float a)
    {
        Value *= a;
        return Value;
    }

    public float Divide(float a)
    {
        Value /= a;
        return Value;
    }

    public float Remainder(float a)
    {
        Value %= a;
        return Value;
    }

    public bool Equal(float a)
    {
        return Value == a;
    }

    public bool NotEqual(float a)
    {
        return Value != a;
    }

    public bool Less(float a)
    {
        return Value < a;
    }

    public bool LessOrEqual(float a)
    {
        return Value <= a;
    }

    public bool Greater(float a)
    {
        return Value > a;
    }

    public bool GreaterOrEqual(float a)
    {
        return Value >= a;
    }
}
