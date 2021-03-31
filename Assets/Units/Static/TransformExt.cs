using UnityEngine;

public static class TransformExt
{
    public static Transform GetParent(Transform t)
    {
        return t.parent;
    }

    public static void SetParent(Transform t, Transform parent)
    {
        t.parent = parent;
    }

    public static void SetParent(Transform t, Transform parent, bool worldPositionStays)
    {
        t.SetParent(parent, worldPositionStays);
    }

    public static Transform Find(Transform t, string name)
    {
        return t.Find(name);
    }
}
