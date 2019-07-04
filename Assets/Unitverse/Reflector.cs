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
    // UnityEventBase methods
    private static MethodInfo m_DirtyPersistentCalls;
    // PersistentCall fields
    private static FieldInfo f_Target, f_MethodName, f_Mode, f_Arguments, f_CallState;
    // ArgumentCache fields
    private static FieldInfo f_ObjectArgument, f_IntArgument, f_FloatArgument, f_StringArgument, f_BoolArgument;
    private static FieldInfo f_ObjectArgumentAssemblyTypeName;

    private static void GetFieldInfo()
    {
        Assembly unityAssembly = typeof(UnityEventBase).Assembly;

        m_DirtyPersistentCalls = typeof(UnityEventBase).GetMethod("DirtyPersistentCalls", FieldFlags);

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
        f_ObjectArgumentAssemblyTypeName = argumentCacheType.GetField("m_ObjectArgumentAssemblyTypeName", FieldFlags);
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
        reflect.Invoke();
    }

    public void SetTarget(Object o)
    {
        foreach (var item in calls)
            f_Target.SetValue(item, o);

        // make sure the event recognizes the changes we made
        m_DirtyPersistentCalls.Invoke(reflect, new object[0]);
    }

    private System.Type[] GetTypeArray(object argumentCache, PersistentListenerMode mode)
    {
        switch (mode)
        {
            case PersistentListenerMode.Object:
                var type = (string)f_ObjectArgumentAssemblyTypeName.GetValue(argumentCache);
                return new System.Type[1] { System.Type.GetType(type) };
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
