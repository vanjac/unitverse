using UnityEngine;

[AddComponentMenu("Units/Filters/Component Filter")]
public class ComponentFilter : Filter
{
    [SerializeField]
    private string _componentType;
    public string ComponentType
    {
        get { return _componentType; }
        set { _componentType = value; }
    }

    protected override bool MatchImpl(GameObject gameObject)
    {
        return gameObject.GetComponent(ComponentType) != null;
    }
}
