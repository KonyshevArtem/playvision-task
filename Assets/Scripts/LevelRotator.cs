using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class receives drag input and rotates level to drag delta.
/// </summary>
public class LevelRotator : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject pivot;
    [SerializeField] private Vector2 rotationSensitivity;

    public void OnDrag(PointerEventData eventData)
    {
        RotateLevel(eventData.delta);
    }

    /// <summary>
    /// Rotate level geometry around pivot.
    /// </summary>
    /// <param name="delta">Rotation angle delta</param>
    private void RotateLevel(Vector2 delta)
    {
        level.transform.RotateAround(pivot.transform.position, Vector3.back, delta.x * rotationSensitivity.x);
        level.transform.RotateAround(pivot.transform.position, Vector3.right, delta.y * rotationSensitivity.y);
    }
}