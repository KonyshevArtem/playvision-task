using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 offset;

    private void Update()
    {
        transform.position = target.transform.position + offset;
        transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
    }
}
