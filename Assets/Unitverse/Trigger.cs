using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [System.Serializable]
    public class TriggerEvent : UnityEvent<Collider> { }

    public GameObject targetObject;
    public string targetTag;
    public LayerMask targetLayers = -1;
    public bool onlyFirstObject;
    public TriggerEvent enter, exit;

    private int numTouching;

    private bool ColliderMatches(Collider c)
    {
        return (((1 << c.gameObject.layer) & targetLayers) != 0) &&
            (c.gameObject == targetObject || c.tag == targetTag
                || (targetObject == null && targetTag == ""));
    }

    private void CollisionEnter(Collider c)
    {
        if (ColliderMatches(c))
        {
            numTouching ++;
            if (!onlyFirstObject || numTouching == 1)
                enter.Invoke(c);
        }
    }

    private void CollisionExit(Collider c)
    {
        if (ColliderMatches(c))
        {
            numTouching --;
            if (!onlyFirstObject || numTouching == 0)
                exit.Invoke(c);
        }
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
