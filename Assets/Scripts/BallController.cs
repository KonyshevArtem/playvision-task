using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class handles ball control.
/// </summary>
public class BallController : MonoBehaviour, IDragHandler
{
    [SerializeField] public Rigidbody ball;
    [SerializeField] public float forceFactor;

    public void OnDrag(PointerEventData eventData)
    {
        ball.AddForce(
            new Vector3(eventData.delta.x / Screen.width * 320, 0, eventData.delta.y / Screen.height * 526) *
            forceFactor, ForceMode.Impulse);
    }
}