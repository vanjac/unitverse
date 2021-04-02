using UnityEngine;

[AddComponentMenu("Units/Test Event")]
public class TestEvent : Unit
{
    public string note;
    public UltEvents.UltEvent _event;

    [MyBox.ButtonMethod]
    public void Invoke()
    {
        if (_event != null)
            _event.Invoke();
    }
}
