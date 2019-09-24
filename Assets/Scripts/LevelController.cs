using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// This class handles level transitions and restart.
/// </summary>
public class LevelController : Singleton<LevelController>
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<Level> levels;
    [SerializeField] private float totalLevelTransitionTime;

    private int currentLevelId;
    private Vector3 ballStartPosition;
    private float currentLevelTransitionTime;
    private bool isTransitioning;
    private Level prevLevel;

    private void FixedUpdate()
    {
        if (isTransitioning)
        {
            currentLevelTransitionTime += Time.fixedDeltaTime;
            UpdateLevelTransition();
            if (currentLevelTransitionTime >= totalLevelTransitionTime)
            {
                FinishLevelTransition();
            }
        }
    }

    /// <summary>
    /// Restart current scene.
    /// </summary>
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Activate next level and store reference to previous level.
    /// </summary>
    /// <param name="nextLevelPosition">Position of next level</param>
    /// <returns>Next level</returns>
    private Level ActivateNextLevel(Vector3 nextLevelPosition)
    {
        prevLevel = levels[currentLevelId];
        currentLevelId = (currentLevelId + 1) % levels.Count;
        levels[currentLevelId].Activate(nextLevelPosition);
        return levels[currentLevelId];
    }

    /// <summary>
    /// Activate next level, disable level rotation and begin ball animation.
    /// </summary>
    /// <param name="nextLevelPosition">Next level position</param>
    public void BeginLevelTransition(Vector3 nextLevelPosition)
    {
        Level nextLevel = ActivateNextLevel(nextLevelPosition);
        LevelRotator.GetInstance().SetNewLevel(nextLevel.gameObject);
        LevelRotator.GetInstance().IsRotationEnabled = false;

        ballStartPosition = ball.transform.position;
        currentLevelTransitionTime = 0;
        isTransitioning = true;
    }

    /// <summary>
    /// Set ball position during transition between levels.
    /// </summary>
    private void UpdateLevelTransition()
    {
        ball.transform.position = Vector3.Lerp(ballStartPosition,
            levels[currentLevelId].SphereLandingPoint.transform.position,
            currentLevelTransitionTime / totalLevelTransitionTime);
    }

    /// <summary>
    /// Deactivate prev level and enable level rotation.
    /// </summary>
    private void FinishLevelTransition()
    {
        isTransitioning = false;
        prevLevel.Deactivate();
        LevelRotator.GetInstance().IsRotationEnabled = true;
    }
}