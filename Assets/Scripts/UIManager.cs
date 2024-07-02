using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public void RestartGame()
    {
        gameManager.HideDeathUI();
        SceneManager.LoadScene("CrashSite");
    }

    public void QuitToMainMenu()
    {
        gameManager.HideDeathUI();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        gameManager.ResumeGame();
    }

    public void OpenSettings()
    {
        gameManager.settingsMenuUI.SetActive(true);
        gameManager.SetCursorState(false);
    }

    public void CloseSettings()
    {
        gameManager.settingsMenuUI.SetActive(false);
        gameManager.SetCursorState(true);
    }
}