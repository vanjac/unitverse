using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public int branch;
    public List<UnityEvent> events;

    public void SetBranch(int branch)
    {
        this.branch = branch;
    }

    public void Fire()
    {
        if (branch >= 0 && branch < events.Count)
            events[branch].Invoke();
    }
}
