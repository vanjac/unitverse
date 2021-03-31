using System.Collections.Generic;
using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_case
[AddComponentMenu("Units/Event List")]
public class EventList : MonoBehaviour
{
    public UltEvents.UltEvent[] events;

    void Start() { }  // enable checkbox

    public void InvokeIndex(int index)
    {
        if (enabled && events != null
                && index >= 0 && index < events.Length
                && events[index] != null)
            events[index].Invoke();
    }

    public void InvokeRandom()
    {
        if (enabled && events != null)
        {
            var e = events[Random.Range(0, events.Length)];
            if (e != null)
                e.Invoke();
        }
    }
}
