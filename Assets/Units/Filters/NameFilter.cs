using UnityEngine;
using System.Text.RegularExpressions;

[AddComponentMenu("Units/Filters/Name Filter")]
public class NameFilter : Filter
{
    [SerializeField, Tooltip("Supports * and ? wildcards.")]
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    protected override bool MatchImpl(GameObject gameObject)
    {
        // https://stackoverflow.com/a/30300521
        string pattern = "^" + Regex.Escape(_name)
            .Replace("\\?", ".").Replace("\\*", ".*") + "$";
        return Regex.IsMatch(gameObject.name, pattern);
    }
}
