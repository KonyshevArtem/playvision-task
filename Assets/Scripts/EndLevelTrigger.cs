using UnityEngine;

/// <summary>
/// This class handles level end.
/// </summary>
public class EndLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EndLevel();    
    }
    
    /// <summary>
    /// Begin level transition with next level 50 units down from this gameObject.
    /// </summary>
    private void EndLevel()
    {
        Vector3 nextLevelPosition = transform.position + Vector3.down * 50;
        LevelController.GetInstance().BeginLevelTransition(nextLevelPosition);
    }
}