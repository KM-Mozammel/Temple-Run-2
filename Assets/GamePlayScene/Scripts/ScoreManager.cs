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

    [Header("Animation Settings")]
    [Tooltip("How long the death animation takes to complete before showing the panel")]
    public float deathAnimationDelay = 2.0f; 

    [Header("Scene Navigation")]
    public string mainMenuSceneName = "StartScene"; 

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
            // Start the coroutine instead of calling the method directly
            StartCoroutine(TriggerGameOverRoutine());
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

    // Changed into a Coroutine to create a delay
    private System.Collections.IEnumerator TriggerGameOverRoutine()
    {
        isGameOver = true; // Instantly flag true so Update() stops running logic
        
        // Wait here while the character plays the death animation
        yield return new WaitForSeconds(deathAnimationDelay);

        // Calculate and show final values after the wait window
        float finalDistance = playerTransform.position.z - startZPosition;
        if (finalDistance < 0) finalDistance = 0;

        if (finalDistanceText != null) 
            finalDistanceText.text = "Total Distance: " + Mathf.FloorToInt(finalDistance).ToString() + "m";
        
        if (finalScoreText != null) 
            finalScoreText.text = "Obstacles Cleared: " + score.ToString();

        if (gameOverPanel != null) 
            gameOverPanel.SetActive(true); 

        Time.timeScale = 0f; // Freeze game actions only AFTER the panel appears
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(mainMenuSceneName);
    }
}