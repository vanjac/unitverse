using UnityEngine;

[AddComponentMenu("Units/Variables/Int Variable")]
public class IntVariable : Variable<int>
{
    public int Add(int a)
    {
        Value += a;
        return Value;  // returning assignment doesn't call getter
    }

    public int Subtract(int a)
    {
        Value -= a;
        return Value;
    }

    public int Multiply(int a)
    {
        Value *= a;
        return Value;
    }

    public int Divide(int a)
    {
        Value /= a;
        return Value;
    }

    public int Remainder(int a)
    {
        Value %= a;
        return Value;
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
