using UnityEngine;

// https://developer.valvesoftware.com/wiki/Math_counter
[AddComponentMenu("Units/Counter")]
public class Counter : IntVariable
{
    private struct CounterState
    {
        public bool atMin, atMax;
    }

    [SerializeField]
    private MyBox.MinMaxInt range;
    public bool clamp;

    public UltEvents.UltEvent hitMin, hitMax;
    public UltEvents.UltEvent changedFromMin, changedFromMax;

    public int Min
    {
        get { return range.Min; }
        set
        {
            var oldState = GetState(Value);
            int oldValue = Value;
            SetMinSilent(value);
            // don't call StateChange twice
            if (oldValue != Value)
                base.OnChanged(oldValue, Value);
            StateChange(oldState, GetState(Value));
        }
    }

    public int Max
    {
        get { return range.Max; }
        set
        {
            var oldState = GetState(Value);
            int oldValue = Value;
            SetMaxSilent(value);
            if (oldValue != Value)
                base.OnChanged(oldValue, Value);
            StateChange(oldState, GetState(Value));
        }
    }

    private CounterState GetState(int value)
    {
        return new CounterState
        {
            atMin = value <= Min,
            atMax = value >= Max
        };
    }

    protected override int ConstrainValue(int value)
    {
        var state = GetState(value);
        if (!clamp)
            return value;
        else if (state.atMin)
            return range.Min;
        else if (state.atMax)
            return range.Max;
        else
            return Value;
    }

    protected override void OnChanged(int oldValue, int newValue)
    {
        base.OnChanged(oldValue, newValue);
        StateChange(GetState(oldValue), GetState(newValue));
    }

    private void StateChange(CounterState oldState, CounterState newState)
    {
        if (newState.atMin && !oldState.atMin && hitMin != null)
            hitMin.Invoke();
        else if (!newState.atMin && oldState.atMin && changedFromMin != null)
            changedFromMin.Invoke();

        if (newState.atMax && !oldState.atMax && hitMax != null)
            hitMax.Invoke();
        else if (!newState.atMax && oldState.atMax && changedFromMax != null)
            changedFromMax.Invoke();
    }

    public void SetMinSilent(int value)
    {
        range.Min = value;
        UpdateValue();
    }

    public void SetMaxSilent(int value)
    {
        range.Max = value;
        UpdateValue();
    }

    public bool AtMin()
    {
        return GetState(Value).atMin;
    }

    public bool AtMax()
    {
        return GetState(Value).atMax;
    }
}
