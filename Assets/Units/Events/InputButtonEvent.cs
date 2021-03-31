using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Units/Input Button Event")]
public class InputButtonEvent : MonoBehaviour
{
    [SerializeField]
    private string _button;
    public string Button
    {
        get { return _button; }
        set { _button = value; }
    }

    public UltEvents.UltEvent down, up;

    void Update()
    {
        if (Input.GetButtonDown(Button) && down != null)
            down.Invoke();
        if (Input.GetButtonUp(Button) && up != null)
            up.Invoke();
    }
}
