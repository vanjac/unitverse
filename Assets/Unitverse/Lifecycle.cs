using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lifecycle : MonoBehaviour
{
    public UnityEvent awake, start, enable, disable, destroy;

    void Awake()
    {
        awake.Invoke();
    }

    void Start()
    {
        start.Invoke();
    }

    void OnEnable()
    {
        enable.Invoke();
    }

    void OnDisable()
    {
        disable.Invoke();
    }

    void OnDestroy()
    {
        destroy.Invoke();
    }
}
