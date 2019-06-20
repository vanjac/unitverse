using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    public int count = 0, threshold = 1;
    public bool eventOnStart;
    public UnityEvent overThreshold, underThreshold;

    void Start()
    {
        if (eventOnStart)
        {
            if (count >= threshold)
                overThreshold.Invoke();
            else
                underThreshold.Invoke();
        }
    }

    public void SetCount(int c)
    {
        int oldCount = count;
        count = c;
        if (oldCount < threshold && count >= threshold)
            overThreshold.Invoke();
        else if (oldCount >= threshold && count < threshold)
            underThreshold.Invoke();
    }

    public void CountUp()
    {
        SetCount(count + 1);
    }

    public void CountDown()
    {
        SetCount(count - 1);
    }
}
