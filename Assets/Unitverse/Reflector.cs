using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class Reflector : MonoBehaviour
{
    public UnityEvent reflect;

    private IEnumerable calls; // List<UnityEngine.Events.PersistentCall>

    private const BindingFlags FieldFlags =
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    // UnityEventBase methods
    private static MethodInfo m_DirtyPersistentCalls;
    // PersistentCall fields
    private static FieldInfo f_Target;
    // PersistentCall methods
    private static MethodInfo m_get_mode, m_get_arguments;
    // ArgumentCache fields
    private static FieldInfo f_ObjectArgument, f_ObjectArgumentAssemblyTypeName;

    private static void GetFieldInfo()
    {
        Assembly unityAssembly = typeof(UnityEventBase).Assembly;

        m_DirtyPersistentCalls = typeof(UnityEventBase).GetMethod("DirtyPersistentCalls", FieldFlags);

        var persistentCallType = unityAssembly.GetType("UnityEngine.Events.PersistentCall");
        f_Target = persistentCallType.GetField("m_Target", FieldFlags);
        m_get_mode = persistentCallType.GetMethod("get_mode", FieldFlags);
        m_get_arguments = persistentCallType.GetMethod("get_arguments", FieldFlags);

        var argumentCacheType = unityAssembly.GetType("UnityEngine.Events.ArgumentCache");
        f_ObjectArgument = argumentCacheType.GetField("m_ObjectArgument", FieldFlags);
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

    public void SetTargets(Object o)
    {
        foreach (var item in calls)
        {
            var oldValue = (Object)f_Target.GetValue(item);
            f_Target.SetValue(item, FindMatchingType(oldValue, o));
        }

        // make sure the event recognizes the changes we made
        m_DirtyPersistentCalls.Invoke(reflect, null);
    }

    public void SetArguments(Object o)
    {
        foreach (var item in calls)
        {
            var mode = (PersistentListenerMode)m_get_mode.Invoke(item, null);
            if (mode == PersistentListenerMode.Object)
            {
                var argumentCache = m_get_arguments.Invoke(item, null);

                var oldValue = (Object)f_ObjectArgument.GetValue(argumentCache);
                var newValue = FindMatchingType(oldValue, o);
                f_ObjectArgument.SetValue(argumentCache, newValue);

                var assemblyTypeName = newValue.GetType().AssemblyQualifiedName;
                // if this is incorrect, the function will show as Missing
                f_ObjectArgumentAssemblyTypeName.SetValue(argumentCache, assemblyTypeName);
            }
        }

        // make sure the event recognizes the changes we made
        m_DirtyPersistentCalls.Invoke(reflect, null);
    }

    private Object FindMatchingType(Object oldValue, Object newValue)
    {
        if (oldValue.GetType().IsAssignableFrom(newValue.GetType()))
            return newValue;

        if ((oldValue is GameObject) && (newValue is Component))
        {
            return ((Component)newValue).gameObject;
        }
        else if ((oldValue is Component) && (newValue is GameObject))
        {
            return ((GameObject)newValue).GetComponent(oldValue.GetType());
        }
        else if ((oldValue is Component) && (newValue is Component))
        {
            return ((Component)newValue).GetComponent(oldValue.GetType());
        }
        else
        {
            return newValue;
        }
    }
}
