using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Units/Filters/Multi Filter")]
public class MultiFilter : Filter
{
    public enum MultiFilterMode
    {
        AND, OR
    }

    public MultiFilterMode mode;
    public Filter[] filters;

    protected override bool MatchImpl(GameObject gameObject)
    {
        foreach (Filter f in filters)
        {
            if (f == null)
                continue;
            bool match = f.Matches(gameObject);
            if ((match && mode == MultiFilterMode.OR)
                || (!match && mode == MultiFilterMode.AND))
            {
                return match;
            }
        }
        return mode == MultiFilterMode.AND;
    }
}
