using UnityEngine;
using UnityEditor;

public static class Hierarchy
{
    [MenuItem("GameObject/Reposition Parent &#g")]
    static void RepositionParent()
    {
        Transform selected = Selection.activeTransform;
        Transform parent = selected.parent;
        Transform[] children = new Transform[parent.childCount];
        for (int i = 0; i < children.Length; i++)
            children[i] = parent.GetChild(i);
            
        Undo.RecordObject(parent, "Reposition parent");
        Undo.RecordObjects(children, "Reposition parent");
        parent.DetachChildren();
        parent.position = selected.position;
        foreach (Transform child in children)
            child.parent = parent;
    }

    [MenuItem("GameObject/Reposition Parent &#g", true)]
    static bool ValidateRepositionParent()
    {
        Transform selected = Selection.activeTransform;
        return selected != null && selected.parent != null
            && PrefabUtility.GetPrefabInstanceStatus(selected.parent)
                == PrefabInstanceStatus.NotAPrefab;
    }
}
