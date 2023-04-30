using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Goes to main menu
    public void PlayMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Goes to Level 1
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    //Close the application
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
