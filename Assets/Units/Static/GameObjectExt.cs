using UnityEngine;

public static class GameObjectExt
{
    public static bool IsActive(GameObject o)
    {
        return o.activeInHierarchy;
    }

    public static void SetActive(GameObject o, bool value)
    {
        o.SetActive(value);
    }

    public static string GetName(GameObject o)
    {
        return o.name;
    }

    public static void SetName(GameObject o, string name)
    {
        o.name = name;
    }

    public static int GetLayer(GameObject o)
    {
        return o.layer;
    }

    public static void SetLayer(GameObject o, int layer)
    {
        o.layer = layer;
    }

    public static string GetTag(GameObject o)
    {
        return o.tag;
    }

    public static void SetTag(GameObject o, string tag)
    {
        o.tag = tag;
    }

    public static Component GetComponent(GameObject o, string type)
    {
        return o.GetComponent(type);
    }

    public static Transform GetTransform(GameObject o)
    {
        return o.transform;
    }

    public static void SendMessage(GameObject o, string methodName)
    {
        o.SendMessage(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessage(GameObject o, string methodName, object value)
    {
        o.SendMessage(methodName, value, SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessageUpwards(GameObject o, string methodName)
    {
        o.SendMessageUpwards(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void SendMessageUpwards(GameObject o, string methodName, object value)
    {
        o.SendMessageUpwards(methodName, value, SendMessageOptions.DontRequireReceiver);
    }

    public static void BroadcastMessage(GameObject o, string methodName)
    {
        o.BroadcastMessage(methodName, "", SendMessageOptions.DontRequireReceiver);
    }

    public static void BroadcastMessage(GameObject o, string methodName, object value)
    {
        o.BroadcastMessage(methodName, value, SendMessageOptions.DontRequireReceiver);
    }
}
