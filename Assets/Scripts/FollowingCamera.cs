using UnityEngine;

/// <summary>
/// This class controls position of game camera.
/// </summary>
public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;


    private void Update()
    {
        PlaceCameraToTarget();
        RotateCameraToTarget();
    }

    /// <summary>
    /// Set position of camera to target position with offset.
    /// </summary>
    private void PlaceCameraToTarget()
    {
        transform.position = target.transform.position + offset;
    }

    /// <summary>
    /// Rotate camera to face target.
    /// </summary>
    private void RotateCameraToTarget()
    {
        Vector3 lookDirection = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}