using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputButtonEvent : MonoBehaviour
{
    public string inputButton;
    public UnityEvent down, up;

    void Update()
    {
        if (Input.GetButtonDown(inputButton))
            down.Invoke();
        if (Input.GetButtonUp(inputButton))
            up.Invoke();
    }
}
