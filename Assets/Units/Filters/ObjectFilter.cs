using UnityEngine;

[AddComponentMenu("Units/Filters/Object Filter")]
public class ObjectFilter : Filter
{
    [SerializeField]
    private GameObject _filterObject;
    public GameObject FilterObject
    {
        get { return _filterObject; }
        set { _filterObject = value; }
    }

    protected override bool MatchImpl(GameObject gameObject)
    {
        return gameObject == FilterObject;
    }
}
