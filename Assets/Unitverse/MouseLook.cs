using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public string inputAxis = "Mouse X";
    public float sensitivity = 5f;
    public Vector3 rotateAxis = Vector3.up;
    public bool clamp = false;
    public float clampMin = -90f, clampMax = 90f;

    void Update()
    {
        float deltaAngle = Input.GetAxis(inputAxis) * sensitivity;
        var rotation = transform.localRotation * Quaternion.AngleAxis(deltaAngle, rotateAxis);
        if (clamp)
        {
            rotation = rotation.normalized;
            float angle = 2 * Mathf.Acos(rotation.w) * Mathf.Rad2Deg;
            float dot = Vector3.Dot(rotateAxis, new Vector3(rotation.x, rotation.y, rotation.z));
            if (dot < 0)
                angle = -angle;
            if (angle < clampMin)
                rotation = Quaternion.AngleAxis(clampMin, rotateAxis);
            else if (angle > clampMax)
                rotation = Quaternion.AngleAxis(clampMax, rotateAxis);
        }
        transform.localRotation = rotation;
    }
}
