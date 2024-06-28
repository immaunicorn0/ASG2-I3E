using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("CrashSite"); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowOptions()
    {
        // Implement options menu
    }

    public void ShowCredits()
    {
        // Implement credits menu
    }

    public void ShowHowToPlay()
    {
        // Implement how-to-play menu
    }
}
