using UnityEngine;

[AddComponentMenu("Units/Variables/Boolean Variable")]
public class BooleanVariable : Variable<bool>
{
    public bool Toggle()
    {
        return Value = !Value;
    }
}
