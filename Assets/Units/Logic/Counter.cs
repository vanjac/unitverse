using UnityEngine;

// https://developer.valvesoftware.com/wiki/Math_counter
[AddComponentMenu("Units/Counter")]
public class Counter : MonoBehaviour
{
    [SerializeField]
    private int _count;
    [SerializeField]
    private MyBox.MinMaxInt range;
    public bool clamp;
    public bool fireOnStart;

    public UltEvents.UltEvent<int> countChanged;
    public UltEvents.UltEvent hitMin, hitMax;
    public UltEvents.UltEvent changedFromMin, changedFromMax;

    // can't just check previous value because min and max might have changed
    // TODO: refactor so these aren't necessary
    private bool atMin, atMax;

    public int Count
    {
        get { return _count; }
        set
        {
            if (!enabled)
                return;
            value = ClampCount(value, out bool nowAtMin, out bool nowAtMax);
            if (value != _count)
            {
                _count = value;
                if (countChanged != null)
                    countChanged.Invoke(_count);
            }

            if (nowAtMin && !atMin && hitMin != null)
                hitMin.Invoke();
            else if (!nowAtMin && atMin && changedFromMin != null)
                changedFromMin.Invoke();
            atMin = nowAtMin;

            if (nowAtMax && !atMax && hitMax != null)
                hitMax.Invoke();
            else if (!nowAtMax && atMax && changedFromMax != null)
                changedFromMax.Invoke();
            atMax = nowAtMax;
        }
    }

    public int Min
    {
        get { return range.Min; }
        set
        {
            if (!enabled)
                return;
            range.Min = value;
            Count = _count;  // call setter
        }
    }

    public int Max
    {
        get { return range.Max; }
        set
        {
            if (!enabled)
                return;
            range.Max = value;
            Count = _count;  // call setter
        }
    }

    private int ClampCount(int value, out bool atMin, out bool atMax)
    {
        atMin = value <= range.Min;
        atMax = value >= range.Max;
        if (!clamp)
            return value;
        else if (atMin)
            return range.Min;
        else if (atMax)
            return range.Max;
        else
            return value;
    }

    private void UpdateStateSilent()
    {
        _count = ClampCount(_count, out atMin, out atMax);  // don't call setter
    }

    void Start()
    {
        if (fireOnStart)
        {
            int initValue = Count;
            _count = int.MinValue;  // silent
            Count = initValue;  // setter, always invoke
        }
        else
        {
            UpdateStateSilent();
        }
    }

    public void SetCountSilent(int value)
    {
        if (!enabled)
            return;
        _count = value;
        UpdateStateSilent();
    }

    public void SetMinSilent(int value)
    {
        if (!enabled)
            return;
        range.Min = value;
        UpdateStateSilent();
    }

    public void SetMaxSilent(int value)
    {
        if (!enabled)
            return;
        range.Max = value;
        UpdateStateSilent();
    }

    public int Add(int value)
    {
        Count += value;  // call setter. when disabled this does nothing
        return Count;  // returning assignment doesn't call getter
    }

    public bool AtMin()
    {
        return atMin;
    }

    public bool AtMax()
    {
        return atMax;
    }
}
