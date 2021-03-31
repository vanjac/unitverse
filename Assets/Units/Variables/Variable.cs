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
            if (!object.Equals(value, _value))  // TODO: slow?
            {
                _value = value;
                if (valueChanged != null)
                    valueChanged.Invoke(_value);
            }
        }
    }

    public UltEvents.UltEvent<T> valueChanged;
}
