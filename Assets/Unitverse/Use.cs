using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Use : MonoBehaviour
{
    private const string USE_BUTTON = "Fire1";
    public UnityEvent useStart, useEnd;
    private bool mouseOver;

    void Update()
    {
        if (mouseOver)
        {
            if (Input.GetButtonDown(USE_BUTTON))
                useStart.Invoke();
            if (Input.GetButtonUp(USE_BUTTON))
                useEnd.Invoke();
        }
    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }
}
