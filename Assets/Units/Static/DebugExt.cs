using UnityEngine;

public static class DebugExt
{
    public static void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public static void LogErrorMessage(string message)
    {
        Debug.LogError(message);
    }

    public static void LogFormatObjects(string format,
    object arg1)
    {
        Debug.LogFormat(format, arg1);
    }

    public static void LogFormatObjects(string format,
    object arg1, object arg2)
    {
        Debug.LogFormat(format, arg1, arg2);
    }

    public static void LogFormatObjects(string format,
    object arg1, object arg2, object arg3)
    {
        Debug.LogFormat(format, arg1, arg2, arg3);
    }

    public static void LogFormatObjects(string format,
    object arg1, object arg2, object arg3, object arg4)
    {
        Debug.LogFormat(format, arg1, arg2, arg3, arg4);
    }
}
