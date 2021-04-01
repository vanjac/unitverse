using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_branch
[AddComponentMenu("Units/Branch")]
public class Branch : BooleanVariable
{
    public UltEvents.UltEvent True, False;

    public void Test()
    {
        if (Value && True != null)
            True.Invoke();
        else if (!Value && False != null)
            False.Invoke();
    }

    public void SetTest(bool value)
    {
        Value = value;
        Test();
    }

    public bool ToggleTest()
    {
        Toggle();
        Test();
        return Value;
    }
}
