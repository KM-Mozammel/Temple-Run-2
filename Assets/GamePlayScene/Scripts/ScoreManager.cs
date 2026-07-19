using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;
    public Text distanceText;
    public Text scoreText;
    
    [Header("Game Over UI")]
    public GameObject gameOverPanel; 
    public Text finalDistanceText;   
    public Text finalScoreText;      

    [Header("Scene Navigation")]
    public string mainMenuSceneName = "StartScene"; // স্টার্ট সিনের নাম

    private float startZPosition;
    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false); 
        
        if (playerTransform != null)
        {
            startZPosition = playerTransform.position.z;
        }
        UpdateScoreUI();
    }

    void Update()
    {
        if (isGameOver) return;
        if (playerTransform == null || distanceText == null) return;

        PlayerController player = playerTransform.GetComponent<PlayerController>();
        if (player != null && player.forwardSpeed <= 0f)
        {
            TriggerGameOver();
            return;
        }

        float currentDistance = playerTransform.position.z - startZPosition;
        if (currentDistance < 0) currentDistance = 0;

        distanceText.text = "Distance: " + Mathf.FloorToInt(currentDistance).ToString() + "m";
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
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

    void TriggerGameOver()
    {
        isGameOver = true;
        
        float finalDistance = playerTransform.position.z - startZPosition;
        if (finalDistance < 0) finalDistance = 0;

        if (finalDistanceText != null) 
            finalDistanceText.text = "Total Distance: " + Mathf.FloorToInt(finalDistance).ToString() + "m";
        
        if (finalScoreText != null) 
            finalScoreText.text = "Obstacles Cleared: " + score.ToString();

        if (gameOverPanel != null) 
            gameOverPanel.SetActive(true); 

        Time.timeScale = 0f; // গেম ওভার স্ক্রিন আসার সাথে সাথে গেম ফ্রিজ করা
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    // --- নতুন যোগ করা ফাংশন: মেইন মেনু বা স্টার্ট সিনে ফিরে যাওয়ার জন্য ---
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // টাইম স্কেল নরমাল করা যাতে মেইন মেনু ফ্রিজ না থাকে
        SceneManager.LoadScene(mainMenuSceneName);
    }
}