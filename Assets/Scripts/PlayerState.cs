using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerState
{
    public static int currentHealth;
    public static int currentAmmo;
    public static int currentCrystals;

    public static void ResetState()
    {
        currentHealth = 100; // Default health
        currentAmmo = 0; // Default ammo
        currentCrystals = 2; // Default crystals
    }
}
