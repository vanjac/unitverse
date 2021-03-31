using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_branch
[AddComponentMenu("Units/Branch")]
public class Branch : MonoBehaviour
{
    [SerializeField]
    private bool _state;
    public bool State
    {
        get { return _state; }
        set { _state = value; }
    }

    public UltEvents.UltEvent True, False;

    public void Test()
    {
        if (State && True != null)
            True.Invoke();
        else if (!State && False != null)
            False.Invoke();
    }

    public void SetTest(bool value)
    {
        State = value;
        Test();
    }

    public void Toggle()
    {
        State = !State;
    }

    public void ToggleTest()
    {
        Toggle();
        Test();
    }
}
