using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [Header("UI Settings")]
    [Tooltip("The button that represents level 1 in the level select menu")]
    [SerializeField] private Button level1Button;

    [Tooltip("The button that represents level 2 in the level select menu")]
    [SerializeField] private Button level2Button;

    [Tooltip("The button that represents level 3 in the level select menu")]
    [SerializeField] private Button level3Button;

    [Tooltip("The game object that represents the commands UI canvas")]
    public GameObject commandsCanvas;

    [Tooltip("A flag that indicates whether the commands UI is currently active")]
    public bool isCommandsActive = false;

    [Tooltip("The game object that represents the scoreboard UI canvas")]
    public GameObject scoreboardCanvas;

    [Tooltip("A flag that indicates whether the scoreboard UI is currently active")]
    public bool isScoreboardActive = false;

    [Tooltip("The text component that displays the result for level 1 in the scoreboard UI")]
    public TMP_Text level1Result;

    [Tooltip("The text component that displays the result for level 2 in the scoreboard UI")]
    public TMP_Text level2Result;

    [Tooltip("The text component that displays the result for level 3 in the scoreboard UI")]
    public TMP_Text level3Result;

    [Tooltip("An array that stores the results for all levels in the scoreboard")]
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

    // Method that toggles the display of the commands UI canvas
    public void PlayCommands()
    {

        if (isCommandsActive)
        {
            // Deactivate the commands UI canvas
            commandsCanvas.SetActive(false);
            // Set the flag for commands UI being active to false
            isCommandsActive = false;
        }
        else
        {
            // Activate the commands UI canvas
            commandsCanvas.SetActive(true);
            // Set the flag for commands UI being active to true
            isCommandsActive = true;
        }
    }

    // Method that toggles the display of the scoreboard UI canvas
    public void ShowScoreboard()
    {
        // If the scoreboard UI is currently active
        if (isScoreboardActive)
        {
            // Deactivate the scoreboard UI canvas
            scoreboardCanvas.SetActive(false);
            // Set the flag for scoreboard UI being active to false
            isScoreboardActive = false;
        }
        else
        {
            // Activate the scoreboard UI canvas
            scoreboardCanvas.SetActive(true);
            // Set the flag for scoreboard UI being active to true
            isScoreboardActive = true;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}