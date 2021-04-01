using UnityEngine;

public abstract class Variable<T> : MonoBehaviour
{
    [SerializeField]
    private T _value;
    public T Value
    {
        get { return _value; }
        set
        {
            T oldValue = _value;
            SetValueSilent(value);
            if (!object.Equals(oldValue, _value))  // TODO: slow?
                OnChanged(oldValue, _value);
        }
    }

    public UltEvents.UltEvent<T> valueChanged;

    protected virtual T ConstrainValue(T value)
    {
        return value;
    }

    // NOT called when SetValueSilent is called
    protected virtual void OnChanged(T oldValue, T newValue)
    {
        if (valueChanged != null)
            valueChanged.Invoke(newValue);
    }

    protected void UpdateValue()
    {
        _value = ConstrainValue(_value);
    }

    public void SetValueSilent(T value)
    {
        _value = value;
        UpdateValue();
    }
}
