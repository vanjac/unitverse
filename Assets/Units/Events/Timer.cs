using UnityEngine;

// https://developer.valvesoftware.com/wiki/Logic_timer
[AddComponentMenu("Units/Events/Timer")]
public class Timer : Unit
{
    [SerializeField]
    private float _interval;
    public float Interval
    {
        get { return _interval; }
        set { _interval = value; }
    }

    public UltEvents.UltEvent fire;

    private float nextTime;

    void OnEnable()
    {
        Reset();
    }

    void Reset()
    {
        nextTime = Time.time + Interval;
    }

    void Update()
    {
        while (Interval > 0 && Time.time >= nextTime)
        {
            fire.Invoke();
            nextTime += Interval;
        }
    }
}
