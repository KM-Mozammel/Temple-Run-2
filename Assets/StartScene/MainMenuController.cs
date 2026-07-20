using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject namePanel;
    public GameObject mainMenuPanel;

    [Header("Inputs & Texts")]
    public InputField nameInputField;
    public Text welcomeText;

    [Header("Scene Settings")]
    public string gameplaySceneName = "Gameplay";

    // Path for log file (same folder as .exe)
    private string logFilePath;

    void Awake()
    {
        // Application.dataPath points to "<exeFolder>/YourGame_Data"
        // So we go one directory up to reach the .exe folder
        string exeFolder = Directory.GetParent(Application.dataPath).FullName;
        logFilePath = Path.Combine(exeFolder, "GameLog.txt");

        Log("Game started. Log file created at: " + logFilePath);
    }

    void Start()
    {
        try
        {
            // Force default pointer
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Log("Cursor set to default pointer.");

            Log("Start() called.");

            // Log panel states
            Log("NamePanel activeSelf: " + (namePanel != null && namePanel.activeSelf));
            Log("MainMenuPanel activeSelf: " + (mainMenuPanel != null && mainMenuPanel.activeSelf));

            // Log input field and text references
            Log("NameInputField assigned: " + (nameInputField != null));
            Log("WelcomeText assigned: " + (welcomeText != null));

            if (!PlayerPrefs.HasKey("PlayerName"))
            {
                Log("No PlayerName found. Showing name panel.");
                namePanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                Log("NamePanel setActive(true), MainMenuPanel setActive(false).");
            }
            else
            {
                Log("PlayerName found: " + PlayerPrefs.GetString("PlayerName"));
                ShowMainMenu();
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in Start(): " + ex.Message);
        }
    }

    public void SaveNameAndContinue()
    {
        try
        {
            Log("SaveNameAndContinue() called.");
            string playerName = nameInputField.text.Trim();

            if (!string.IsNullOrEmpty(playerName))
            {
                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();
                Log("PlayerName saved: " + playerName);
                ShowMainMenu();
            }
            else
            {
                Log("Name input was empty.");
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in SaveNameAndContinue(): " + ex.Message);
        }
    }

    void ShowMainMenu()
    {
        try
        {
            Log("ShowMainMenu() called.");
            namePanel.SetActive(false);
            mainMenuPanel.SetActive(true);

            if (welcomeText != null)
            {
                string playerName = PlayerPrefs.GetString("PlayerName");
                welcomeText.text = "Welcome, " + playerName + "!";
                Log("Welcome text updated for: " + playerName);
            }
        }
        catch (System.Exception ex)
        {
            Log("Error in ShowMainMenu(): " + ex.Message);
        }
    }

    public void PlayGame()
    {
        try
        {
            Log("PlayGame() called. Loading scene: " + gameplaySceneName);
            Time.timeScale = 1f;
            SceneManager.LoadScene(gameplaySceneName);
        }
        catch (System.Exception ex)
        {
            Log("Error in PlayGame(): " + ex.Message);
        }
    }

    // Custom logger method
    private void Log(string message)
    {
        string logEntry = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message;
        Debug.Log(logEntry); // still visible in Unity console
        File.AppendAllText(logFilePath, logEntry + "\n");
    }

    public void QuitGame()
    {
        Log("QuitGame() called. Closing application.");
        Application.Quit();

        // For testing in Editor only
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
