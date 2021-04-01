using UnityEngine;

[AddComponentMenu("Units/Test Event")]
public class TestEvent : MonoBehaviour
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
