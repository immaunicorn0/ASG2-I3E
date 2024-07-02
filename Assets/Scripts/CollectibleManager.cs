using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager instance;
    public TMP_Text crystalText;
    private int crystalCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize crystal count from PlayerState
        crystalCount = PlayerState.currentCrystals;
        UpdateCrystalUI();
    }

    public void CollectCrystal()
    {
        crystalCount++;
        PlayerState.currentCrystals = crystalCount; // Update PlayerState
        UpdateCrystalUI();
        if (crystalCount >= 3) // Assuming 3 crystals to win
        {
            ShowEndGameUI();
        }
    }

    public int GetCrystalCount()
    {
        return crystalCount;
    }

    private void UpdateCrystalUI()
    {
        if (crystalText != null)
        {
            crystalText.text = "Crystals: " + crystalCount.ToString() + "/2";
        }
    }

    private void ShowEndGameUI()
    {
        // Implement showing the congrats message and end game options
    }
}
