using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool position = true, rotation, scale;
    public Transform target, relative;

    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    public Transform Relative
    {
        get
        {
            return relative;
        }
        set
        {
            relative = value;
        }
    }

    public void TeleportToTarget()
    {
        Transform rel = relative;
        if (relative == null)
            rel = transform;
        if (position)
            transform.position += target.position - rel.position;
        if (rotation)
            transform.rotation = target.rotation * Quaternion.Inverse(rel.rotation) * transform.rotation;
        if (scale)
            transform.localScale = new Vector3(
                transform.localScale.x * target.lossyScale.x / rel.lossyScale.x,
                transform.localScale.y * target.lossyScale.y / rel.lossyScale.y,
                transform.localScale.z * target.lossyScale.z / rel.lossyScale.z);
    }
}
