using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Units/Events/Input Key Event")]
public class InputKeyEvent : Unit
{
    [SerializeField, MyBox.SearchableEnum]
    private KeyCode _key;
    public KeyCode Key
    {
        get { return _key; }
        set { _key = value; }
    }

    public UltEvents.UltEvent down, up;

    void Update()
    {
        if (Input.GetKeyDown(Key) && down != null)
            down.Invoke();
        if (Input.GetKeyUp(Key) && up != null)
            up.Invoke();
    }
}