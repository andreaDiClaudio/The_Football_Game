using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button level1Button;
    [SerializeField] private Button level2Button;
    [SerializeField] private Button level3Button;

    private void Start()
    {
        // Set level buttons to active or inactive based on which levels are unlocked
        level1Button.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(false);
        level3Button.gameObject.SetActive(false);
    }

    void Update()
    {
        level2Button.gameObject.SetActive(ProgressionManager.IsLevelUnlocked(0));
        level3Button.gameObject.SetActive(ProgressionManager.IsLevelUnlocked(1));
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
        if (ProgressionManager.IsLevelUnlocked(0))
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
        if (ProgressionManager.IsLevelUnlocked(1))
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.LogWarning("Level 3 is locked.");
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