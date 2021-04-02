using UnityEngine;

public static class ComponentExt
{
    public static Component Literal(Component c)
    {
        return c;
    }

    public static GameObject GetGameObject(Component c)
    {
        return c.gameObject;
    }

    public static bool IsEnabled(Component c)
    {
        // :(
        if (c is Behaviour behaviour)
            return behaviour.enabled;
        else if (c is Renderer renderer)
            return renderer.enabled;
        else if (c is Collider collider)
            return collider.enabled;  // Collider2D inherits from Behaviour
        else if (c is Cloth cloth)
            return cloth.enabled;
        else if (c is LODGroup lodGroup)
            return lodGroup.enabled;
        return true;
    }

    public static void SetEnabled(Component c, bool value)
    {
        if (c is Behaviour behaviour)
            behaviour.enabled = value;
        else if (c is Renderer renderer)
            renderer.enabled = value;
        else if (c is Collider collider)
            collider.enabled = value;
        else if (c is Cloth cloth)
            cloth.enabled = value;
        else if (c is LODGroup lodGroup)
            lodGroup.enabled = value;
    }

    public static string GetTag(Component c)
    {
        return c.tag;
    }

    public static void SetTag(Component c, string tag)
    {
        c.tag = tag;
    }

    public static Component GetComponent(Component c, string type)
    {
        return c.GetComponent(type);
    }

    public static Transform GetTransform(Component c)
    {
        return c.transform;
    }

    public static void SendMessage(Component c, string methodName)
    {
        c.SendMessage(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessage(Component c, string methodName, object value)
    {
        c.SendMessage(methodName, value, SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessageUpwards(Component c, string methodName)
    {
        c.SendMessageUpwards(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessageUpwards(Component c, string methodName, object value)
    {
        c.SendMessageUpwards(methodName, value, SendMessageOptions.DontRequireReceiver);
    }

    public static void BroadcastMessage(Component c, string methodName)
    {
        c.BroadcastMessage(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void BroadcastMessage(Component c, string methodName, object value)
    {
        c.BroadcastMessage(methodName, value, SendMessageOptions.DontRequireReceiver);
    }
}
