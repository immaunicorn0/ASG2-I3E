using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public int enemyCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Count all enemies at the start
        enemyCount = FindObjectsOfType<EnemyAI>().Length;
    }

    public void EnemyDied()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            Debug.Log("All enemies defeated.");
        }
    }
}
