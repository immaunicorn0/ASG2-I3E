using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int totalCollectibles = 5;
    public int collectedItems = 0;

    void Awake()
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

    public void CollectItem()
    {
        collectedItems++;
        if (collectedItems == totalCollectibles)
        {
            // Unlock final area
        }
    }

    public void PlayerDied()
    {
        // Show death UI
    }
}
