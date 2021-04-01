using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://developer.valvesoftware.com/wiki/Triggers
[AddComponentMenu("Units/Events/Trigger")]
public class Trigger : MonoBehaviour
{
    [SerializeField]
    private Filter _triggerFilter;
    public Filter TriggerFilter
    {
        get { return _triggerFilter; }
        set { _triggerFilter = value; }
    }

    public UltEvents.UltEvent<GameObject> startTouch, endTouch;
    public UltEvents.UltEvent<GameObject> startTouchAll, endTouchAll;

    private HashSet<GameObject> touching = new HashSet<GameObject>();

    private bool ColliderMatches(Collider c)
    {
        if (TriggerFilter == null)
            return true;
        return TriggerFilter.Matches(c);
    }

    private void CollisionEnter(Collider c)
    {
        if (!enabled)
            return;
        GameObject o = c.gameObject;
        if (ColliderMatches(c) && touching.Add(o))
        {
            if (startTouch != null)
                startTouch.Invoke(o);
            if (touching.Count == 1 && startTouchAll != null)
                startTouchAll.Invoke(o);
        }
    }

    private void CollisionExit(Collider c)
    {
        if (!enabled)
            return;
        GameObject o = c.gameObject;
        if (touching.Remove(o))
        {
            if (endTouch != null)
                endTouch.Invoke(o);
            if (touching.Count == 0 && endTouchAll != null)
                endTouchAll.Invoke(o);
        }
    }

    public bool IsTouchingAny()
    {
        return touching.Count != 0;
    }

    public bool IsTouching(GameObject o)
    {
        return touching.Contains(o);
    }

    void OnEnable()
    {
        touching.Clear();
    }

    void OnTriggerEnter(Collider c)
    {
        CollisionEnter(c);
    }

    void OnTriggerExit(Collider c)
    {
        CollisionExit(c);
    }

    void OnCollisionEnter(Collision c)
    {
        CollisionEnter(c.collider);
    }

    void OnCollisionExit(Collision c)
    {
        CollisionExit(c.collider);
    }
}
