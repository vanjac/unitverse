using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipFlop : MonoBehaviour
{
    public bool startOn, eventOnStart;
    public UnityEvent turnOn, turnOff;
    private bool _on;
    public bool on
    {
        get
        {
            return _on;
        }
        set
        {
            if (_on != value)
            {
                _on = value;
                if (_on)
                    turnOn.Invoke();
                else
                    turnOff.Invoke();
            }
        }
    }

    void Awake()
    {
        _on = startOn;
    }

    void Start()
    {
        if (eventOnStart)
        {
            if (_on)
                turnOn.Invoke();
            else
                turnOff.Invoke();
        }
    }

    public void Toggle()
    {
        on = !on;
    }
}
