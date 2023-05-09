using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;
    public GameObject commandsCanvas;
    public bool isCommandsActive = false;
    public GameObject scoreboardCanvas;
    public bool isScoreboardActive = false;

    public TMP_Text level1Result;
    public TMP_Text level2Result;
    public TMP_Text level3Result;
    public static string[] scoreboard;

    private void Start()
    {
        // Set level buttons to active or inactive based on which levels are unlocked
        level1Button.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(false);
        level3Button.gameObject.SetActive(false);
        commandsCanvas.SetActive(false);
        scoreboardCanvas.SetActive(false);

        // Load the scoreboard values from PlayerPrefs
        scoreboard = new string[] { "", "", "" };
        scoreboard[0] = PlayerPrefs.GetString("Level1Score", "Level 1: none");
        scoreboard[1] = PlayerPrefs.GetString("Level2Score", "Level 2: none");
        scoreboard[2] = PlayerPrefs.GetString("Level3Score", "Level 3: none");
    }

    void Update()
    {
        level2Button.gameObject.SetActive(ProgressionManager.IsLevelUnlocked(1));
        level3Button.gameObject.SetActive(ProgressionManager.IsLevelUnlocked(2));

        level1Result.text = scoreboard[0];
        level2Result.text = scoreboard[1];
        level3Result.text = scoreboard[2];
    }


    public static void UpdateScoreboard(int levelIndex, string scoreText)
    {

        // Update the scoreboard array with the new score
        scoreboard[levelIndex] = "Level " + (levelIndex + 1) + ": " + scoreText + " seconds";
        PlayerPrefs.SetString("Level1Score", scoreboard[0]);
        PlayerPrefs.SetString("Level2Score", scoreboard[1]);
        PlayerPrefs.SetString("Level3Score", scoreboard[2]);
    }

    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        if (ProgressionManager.IsLevelUnlocked(1))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.LogWarning("Level 2 is locked.");
        }
    }

    public void PlayLevel3()
    {
        if (ProgressionManager.IsLevelUnlocked(2))
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.LogWarning("Level 3 is locked.");
        }
    }

    public void PlayCommands()
    {
        if (isCommandsActive)
        {
            commandsCanvas.SetActive(false);
            isCommandsActive = false;
            Debug.Log(isCommandsActive);
        }
        else
        {
            commandsCanvas.SetActive(true);
            isCommandsActive = true;
        }
    }

    public void ShowScoreboard()
    {
        if (isScoreboardActive)
        {
            scoreboardCanvas.SetActive(false);
            isScoreboardActive = false;
        }
        else
        {
            scoreboardCanvas.SetActive(true);
            isScoreboardActive = true;
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.SetString("Level1Score", "Level 1: none");
        PlayerPrefs.SetString("Level2Score", "Level 1: none");
        PlayerPrefs.SetString("Level3Score", "Level 1: none");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}