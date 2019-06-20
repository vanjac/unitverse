using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipFlop : MonoBehaviour
{
    public bool on, eventOnStart;
    public UnityEvent turnOn, turnOff;

    void Start()
    {
        if (eventOnStart)
            Test();
    }

    public void Flip(bool state)
    {
        if (state != on)
        {
            on = state;
            if (on)
                turnOn.Invoke();
            else
                turnOff.Invoke();
        }
    }

    public void Test()
    {
        if (on)
            turnOn.Invoke();
        else
            turnOff.Invoke();
    }

    public void Toggle()
    {
        Flip(!on);
    }
}
