using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_compare
[AddComponentMenu("Units/Variables/Float Variable")]
public class FloatVariable : Variable<float>
{
    public float Add(float a)
    {
        return Value += a;
    }

    public float Subtract(float a)
    {
        return Value -= a;
    }

    public float Multiply(float a)
    {
        return Value *= a;
    }

    public float Divide(float a)
    {
        return Value /= a;
    }

    public float Remainder(float a)
    {
        return Value %= a;
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
