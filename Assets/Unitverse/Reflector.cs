using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Reflector : MonoBehaviour
{
    public UnityEvent reflect;

    private Object overrideTarget;

    private IEnumerable calls; // List<UnityEngine.Events.PersistentCall>

    private const BindingFlags FieldFlags =
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    // PersistentCall fields
    private static FieldInfo f_Target, f_MethodName, f_Mode, f_Arguments, f_CallState;
    // ArgumentCache fields
    private static FieldInfo f_ObjectArgument, f_IntArgument, f_FloatArgument, f_StringArgument, f_BoolArgument;

    private static void GetFieldInfo()
    {
        Assembly unityAssembly = typeof(UnityEventBase).Assembly;

        var persistentCallType = unityAssembly.GetType("UnityEngine.Events.PersistentCall");
        f_Target = persistentCallType.GetField("m_Target", FieldFlags);
        f_MethodName = persistentCallType.GetField("m_MethodName", FieldFlags);
        f_Mode = persistentCallType.GetField("m_Mode", FieldFlags);
        f_Arguments = persistentCallType.GetField("m_Arguments", FieldFlags);
        f_CallState = persistentCallType.GetField("m_CallState", FieldFlags);
        
        var argumentCacheType = unityAssembly.GetType("UnityEngine.Events.ArgumentCache");
        f_ObjectArgument = argumentCacheType.GetField("m_ObjectArgument", FieldFlags);
        f_IntArgument = argumentCacheType.GetField("m_IntArgument", FieldFlags);
        f_FloatArgument = argumentCacheType.GetField("m_FloatArgument", FieldFlags);
        f_StringArgument = argumentCacheType.GetField("m_StringArgument", FieldFlags);
        f_BoolArgument = argumentCacheType.GetField("m_BoolArgument", FieldFlags);
    }

    void Start()
    {
        if (f_Target == null)
            GetFieldInfo();

        // type: UnityEngine.Events.PersistentCallGroup
        object persistentCalls = typeof(UnityEventBase).GetField("m_PersistentCalls", FieldFlags)
            .GetValue(reflect);

        // type: List<UnityEngine.Events.PersistentCall>
        calls = persistentCalls.GetType().GetField("m_Calls", FieldFlags)
            .GetValue(persistentCalls) as IEnumerable;
    }

    public void Fire()
    {
        foreach (var item in calls)
        {
            var callState = (UnityEventCallState)f_CallState.GetValue(item);
            if (callState == UnityEventCallState.Off)
                continue;

            var target = overrideTarget;
            if (target == null)
                target = (Object)f_Target.GetValue(item);
            if (target == null)
                continue;

            var methodName = (string)f_MethodName.GetValue(item);
            if (methodName == "") // not assigned
                continue;

            var mode = (PersistentListenerMode)f_Mode.GetValue(item);
            // UnityEngine.Events.ArgumentCache
            var argumentCache = f_Arguments.GetValue(item);

            MethodInfo targetMethod = UnityEventBase.GetValidMethodInfo(
                target, methodName, GetTypeArray(mode));
            if (targetMethod == null)
            {
                Debug.LogError("No matching method for " + methodName);
                continue;
            }

            object[] arguments = GetArguments(argumentCache, mode);

            try
            {
                targetMethod.Invoke(target, arguments);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    public void SetTarget(Object o)
    {
        overrideTarget = o;
    }

    private System.Type[] GetTypeArray(PersistentListenerMode mode)
    {
        switch (mode)
        {
            case PersistentListenerMode.Object:
                return new System.Type[1] { typeof(Object) };
            case PersistentListenerMode.Int:
                return new System.Type[1] { typeof(int) };
            case PersistentListenerMode.Float:
                return new System.Type[1] { typeof(float) };
            case PersistentListenerMode.String:
                return new System.Type[1] { typeof(string) };
            case PersistentListenerMode.Bool:
                return new System.Type[1] { typeof(bool) };
            default:
                return new System.Type[0];
        }
    }

    private object[] GetArguments(object argumentCache, PersistentListenerMode mode)
    {
        switch (mode)
        {
            case PersistentListenerMode.Object:
                return new object[] { f_ObjectArgument.GetValue(argumentCache) };
            case PersistentListenerMode.Int:
                return new object[] { f_IntArgument.GetValue(argumentCache) };
            case PersistentListenerMode.Float:
                return new object[] { f_FloatArgument.GetValue(argumentCache) };
            case PersistentListenerMode.String:
                return new object[] { f_StringArgument.GetValue(argumentCache) };
            case PersistentListenerMode.Bool:
                return new object[] { f_BoolArgument.GetValue(argumentCache) };
            default:
                return new object[0];
        }
    }
}
