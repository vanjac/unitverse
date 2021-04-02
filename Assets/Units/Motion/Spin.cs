using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Units/Spin")]
public class Spin : Unit
{
    [SerializeField]
    private float _speed = 45;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField]
    private Vector3 _axis = Vector3.up;
    public Vector3 Axis
    {
        get { return _axis; }
        set { _axis = value; }
    }

    private new Rigidbody rigidbody;  // not required

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rigidbody == null)
        {
            float angle = Speed * Time.deltaTime;
            transform.Rotate(Axis, angle, Space.Self);
        }
    }

    void FixedUpdate()
    {
        if (rigidbody != null)
        {
            float angle = Speed * Time.fixedDeltaTime;
            // TODO: doesn't allow combining multiple spin behaviours
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.AngleAxis(angle, Axis));
        }
    }
}
