using UnityEngine;

[AddComponentMenu("Units/Raycaster")]
public class Raycaster : MonoBehaviour
{
    [SerializeField]
    private float _maxDistance = Mathf.Infinity;
    public float MaxDistance
    {
        get { return _maxDistance; }
        set { _maxDistance = value; }
    }

    [SerializeField]
    private LayerMask _mask = Physics.DefaultRaycastLayers;
    public LayerMask Mask
    {
        get { return _mask; }
        set { _mask = value; }
    }

    public QueryTriggerInteraction triggerInteraction
        = QueryTriggerInteraction.UseGlobal;
    
    public UltEvents.UltEvent<Transform> hit;
    public UltEvents.UltEvent miss;

    public bool Raycast()
    {
        bool raycastHit = Physics.Raycast(transform.position, transform.forward,
            out RaycastHit hitInfo, MaxDistance, Mask, triggerInteraction);
        if (raycastHit && hit != null)
            hit.Invoke(hitInfo.transform);  // uses rigidbody if available
        else if (!raycastHit && miss != null)
            miss.Invoke();
        return raycastHit;
    }
}
