using UnityEngine;

public abstract class Variable<T> : MonoBehaviour
{
    [SerializeField]
    private T _value;
    public T Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
