using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceshipInteraction : MonoBehaviour
{
    public TMP_Text depositCrystalsText;
    public GameObject congratsPanel;
    public int requiredCrystals = 3;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DepositCrystals();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            depositCrystalsText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            depositCrystalsText.gameObject.SetActive(false);
        }
    }

    private void DepositCrystals()
    {
        if (CollectibleManager.instance.GetCrystalCount() >= requiredCrystals)
        {
            congratsPanel.SetActive(true);
            depositCrystalsText.gameObject.SetActive(false);
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            // Optionally, provide feedback if not enough crystals
            Debug.Log("Not enough crystals to deposit.");
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main menu");
    }
}
