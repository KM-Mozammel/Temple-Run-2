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
    public string gameplaySceneName = "Gameplay"; // আপনার মেইন গেমপ্লে সিনের নাম

    void Start()
    {
        // PlayerPrefs ব্যবহার করে চেক করা হচ্ছে প্লেয়ার আগে নাম সেভ করেছে কিনা
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            // প্রথমবার গেম ওপেন করলে নামের প্যানেল দেখাবে, মেনু হাইড থাকবে
            namePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
        else
        {
            // নাম অলরেডি থাকলে সরাসরি মূল মেনু দেখাবে
            ShowMainMenu();
        }
    }

    // SubmitNameButton-এর অন-ক্লিক ইভেন্টে এটি যুক্ত হবে
    public void SaveNameAndContinue()
    {
        string playerName = nameInputField.text.Trim();

        if (!string.IsNullOrEmpty(playerName))
        {
            // নাম সেভ করে রাখা হচ্ছে যাতে পরের বার আর না চায়
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            
            ShowMainMenu();
        }
        else
        {
            Debug.LogWarning("Name cannot be empty!");
        }
    }

    void ShowMainMenu()
    {
        namePanel.SetActive(false);
        mainMenuPanel.SetActive(true);

        // প্লেয়ারকে নাম ধরে স্বাগত জানানো
        if (welcomeText != null)
        {
            welcomeText.text = "স্বাগতম, " + PlayerPrefs.GetString("PlayerName") + "!";
        }
    }

    // PlayButton-এর অন-ক্লিক ইভেন্টে এটি যুক্ত হবে
    public void PlayGame()
    {
        Time.timeScale = 1f; // কোনো কারণে টাইম স্কেল পজ থাকলে সচল করা
        SceneManager.LoadScene(gameplaySceneName); // গেমপ্লে সিন লোড
    }
}