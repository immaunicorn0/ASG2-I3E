using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportArea : MonoBehaviour
{
    public string nextSceneName;
    public int requiredCrystals = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CollectibleManager.instance.GetCrystalCount() >= requiredCrystals)
        {
            // Save player state
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                PlayerState.currentHealth = playerHealth.GetCurrentHealth();
            }

            PlayerAmmo playerAmmo = other.GetComponent<PlayerAmmo>();
            if (playerAmmo != null)
            {
                PlayerState.currentAmmo = playerAmmo.GetCurrentAmmo();
            }

            PlayerState.currentCrystals = CollectibleManager.instance.GetCrystalCount();

            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}