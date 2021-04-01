using UnityEngine;

[AddComponentMenu("Units/Variables/String Variable")]
public class StringVariable : Variable<string>
{
    public string Concat(string s)
    {
        Value += s;
        return Value;
    }
}
