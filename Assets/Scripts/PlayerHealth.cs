using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBar healthBar;
    public GameObject deathUI;

    void Start()
    {
        if (PlayerState.currentHealth > 0)
        {
            currentHealth = PlayerState.currentHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        deathUI.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void RestartGame()
    {
        PlayerState.ResetState();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        PlayerState.ResetState();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}