using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;
    public Text distanceText;
    public Text scoreText; // New reference for the Score UI

    private float startZPosition;
    private int score = 0; // Tracks the obstacle score

    void Start()
    {
        if (playerTransform != null)
        {
            startZPosition = playerTransform.position.z;
        }
        UpdateScoreUI();
    }

    void Update()
    {
        if (playerTransform == null || distanceText == null) return;

        float currentDistance = playerTransform.position.z - startZPosition;
        if (currentDistance < 0) currentDistance = 0;

        distanceText.text = "Distance: " + Mathf.FloorToInt(currentDistance).ToString() + "m";
    }

    // Public method called by the player script when an obstacle is cleared
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}