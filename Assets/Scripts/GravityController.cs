using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GravityController : MonoBehaviour, IDragHandler
{
    [SerializeField] private float gravityMultiplier;

    private Vector3 gravityDirection;

    private void Start()
    {
        gravityDirection = Physics.gravity.normalized;
    }

    private void Update()
    {
        Physics.gravity = gravityDirection * gravityMultiplier;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 normalizedDelta = eventData.delta.normalized;
        gravityDirection += new Vector3(normalizedDelta.x, 0, normalizedDelta.y) * Time.deltaTime;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (gravityDirection.sqrMagnitude > 0)
        {
            Handles.ArrowHandleCap(0, Camera.main.transform.position, Quaternion.LookRotation(gravityDirection), 10,
                EventType.Repaint);
        }
    }
#endif
}