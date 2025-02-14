using UnityEngine;

/// <summary>
/// This class represent level object in game.
/// </summary>
public class Level : MonoBehaviour
{
    [SerializeField] private GameObject sphereLandingPoint;
    [SerializeField] private float maxBallDistance;

    public GameObject SphereLandingPoint => sphereLandingPoint;
    public float MaxBallDistance => maxBallDistance;

    /// <summary>
    /// Reset level's rotation, set given position and activate gameObject.
    /// </summary>
    /// <param name="position">Level's position</param>
    public void Activate(Vector3 position)
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = position;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Deactivate level's gameObject.
    /// </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}