using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public GameObject howToPlayPanel;

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
        optionsPanel.SetActive(true);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void BackToMainMenu(GameObject panel)
    {
        panel.SetActive(false);
    }
}
