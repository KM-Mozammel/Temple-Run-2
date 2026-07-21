using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        try
        {
            // Force default pointer
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            if (!PlayerPrefs.HasKey("PlayerName"))
            {
                namePanel.SetActive(true);
                mainMenuPanel.SetActive(false);
            }
            else
            {
                ShowMainMenu();
            }
        }
        catch (System.Exception)
        {
            // Keeping empty catch block to safely encapsulate UI initialization errors if any occur
        }
    }

    public void SaveNameAndContinue()
    {
        try
        {
            string playerName = nameInputField.text.Trim();

            if (!string.IsNullOrEmpty(playerName))
            {
                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();
                ShowMainMenu();
            }
        }
        catch (System.Exception)
        {
        }
    }

    void ShowMainMenu()
    {
        try
        {
            namePanel.SetActive(false);
            mainMenuPanel.SetActive(true);

            if (welcomeText != null)
            {
                string playerName = PlayerPrefs.GetString("PlayerName");
                welcomeText.text = "Welcome, " + playerName + "!";
            }
        }
        catch (System.Exception)
        {
        }
    }

    public void PlayGame()
    {
        try
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(gameplaySceneName);
        }
        catch (System.Exception)
        {
        }
    }

    public void QuitGame()
    {
        Application.Quit();

        // For testing in Editor only
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}