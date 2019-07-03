using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Relay : MonoBehaviour
{
    public enum LimitAction
    {
        Continue, Stop, Wrap
    }

    public int branch;
    public LimitAction limitAction;
    public List<UnityEvent> events = new List<UnityEvent>() { new UnityEvent() };

    public void Fire()
    {
        if (branch >= 0 && branch < events.Count)
            events[branch].Invoke();
    }

    public void SetBranch(int branch)
    {
        this.branch = branch;
    }

    public void CountUp()
    {
        branch += 1;
        if (limitAction == LimitAction.Stop)
        {
            if (branch >= events.Count)
                branch = events.Count - 1;
        }
        else if (limitAction == LimitAction.Wrap)
        {
            while (branch >= events.Count)
                branch -= events.Count;
        }
    }

    public void CountDown()
    {
        branch -= 1;
        if (limitAction == LimitAction.Stop)
        {
            if (branch < 0)
                branch = 0;
        }
        else if (limitAction == LimitAction.Wrap)
        {
            while (branch < 0)
                branch += events.Count;
        }
    }
}
