using UnityEngine;

[AddComponentMenu("Units/Variables/Boolean Variable")]
public class BooleanVariable : Variable<bool>
{
    public bool Toggle()
    {
        Value = !Value;
        return Value;
    }
}
