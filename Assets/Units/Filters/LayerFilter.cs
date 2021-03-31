using UnityEngine;

[AddComponentMenu("Units/Filters/Layer Filter")]
public class LayerFilter : Filter
{
    [SerializeField]
    private LayerMask _mask = ~0;
    public LayerMask Mask
    {
        get { return _mask; }
        set { _mask = value; }
    }

    public int Value
    {
        get { return _mask.value; }
        set { _mask.value = value; }
    }

    protected override bool MatchImpl(GameObject gameObject)
    {
        return ((1 << gameObject.layer) & Mask) != 0;
    }
}
