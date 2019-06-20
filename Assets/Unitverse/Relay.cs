using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Relay : MonoBehaviour
{
    public UnityEvent fire;

    public void Fire()
    {
        fire.Invoke();
    }
}
