using UnityEngine;

[AddComponentMenu("Units/Filters/Tag Filter")]
public class TagFilter : Filter
{
    [SerializeField, MyBox.Tag]
    private string _tag;
    public string Tag
    {
        get { return _tag; }
        set { _tag = value; }
    }

    protected override bool MatchImpl(GameObject gameObject)
    {
        return gameObject.CompareTag(Tag);
    }
}
