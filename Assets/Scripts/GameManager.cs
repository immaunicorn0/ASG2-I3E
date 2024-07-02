using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathUI;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject mainMenuUI;

    private bool isPaused = false;

    void Start()
    {
        // Check the initial state of deathUI and set the cursor state accordingly
        if (deathUI.activeSelf)
        {
            SetCursorState(false);
        }
        else
        {
            SetCursorState(true);
        }
    }

    void Update()
    {
        // Pause the game and show the pause menu when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ShowDeathUI()
    {
        deathUI.SetActive(true);
        SetCursorState(false);
        Time.timeScale = 0f;
    }

    public void HideDeathUI()
    {
        deathUI.SetActive(false);
        SetCursorState(true);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        SetCursorState(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        SetCursorState(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        SetCursorState(true);
        Time.timeScale = 0f;
    }

    public void HideMainMenu()
    {
        mainMenuUI.SetActive(false);
        SetCursorState(true);
        Time.timeScale = 1f;
    }

    public void SetCursorState(bool isCursorLocked)
    {
        Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isCursorLocked;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SetCursorState(true);
    }

    public void QuitToMainMenu()
    {
        HideDeathUI();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}