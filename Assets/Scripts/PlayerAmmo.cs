using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    public int maxAmmo = 100;
    private int currentAmmo;

    void Start()
    {
        if (PlayerState.currentAmmo > 0)
        {
            currentAmmo = PlayerState.currentAmmo;
        }
        else
        {
            currentAmmo = maxAmmo;
        }
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void UseAmmo(int amount)
    {
        currentAmmo -= amount;
        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }
    }

    public void AddAmmo(int amount)
    {
        currentAmmo += amount;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }
}
