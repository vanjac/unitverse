using UnityEngine;

[AddComponentMenu("Units/Variables/Int Variable")]
public class IntVariable : Variable<int>
{
    public int Add(int a)
    {
        return Value += a;
    }

    public int Subtract(int a)
    {
        return Value -= a;
    }

    public int Multiply(int a)
    {
        return Value *= a;
    }

    public int Divide(int a)
    {
        return Value /= a;
    }

    public int Remainder(int a)
    {
        return Value %= a;
    }

    public bool Equal(int a)
    {
        return Value == a;
    }

    public bool NotEqual(int a)
    {
        return Value != a;
    }

    public bool Less(int a)
    {
        return Value < a;
    }

    public bool LessOrEqual(int a)
    {
        return Value <= a;
    }

    public bool Greater(int a)
    {
        return Value > a;
    }

    public bool GreaterOrEqual(int a)
    {
        return Value >= a;
    }
}
