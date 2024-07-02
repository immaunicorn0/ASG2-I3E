using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float stoppingDistance = 1f; // Distance at which enemy stops approaching
    public int maxHealth = 50; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public int damage = 10;

    private bool alreadyAttacked;
    public float timeBetweenAttacks = 1f;

    
    public GameObject crystalCollectiblePrefab;

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("PlayerCapsule");
        if (playerObject != null && playerObject.activeSelf)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found or inactive.");
        }

        currentHealth = maxHealth; // Initialize current health
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(player);

            if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy takes damage: " + damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        EnemyManager.instance.EnemyDied();
        DropCollectible();
        gameObject.SetActive(false);
    }

    void DropCollectible()
    {
        Instantiate(crystalCollectiblePrefab, transform.position, Quaternion.identity);
        if (EnemyManager.instance.enemyCount == 0)
        {
            Instantiate(crystalCollectiblePrefab, transform.position, Quaternion.identity);
        }
    }
}
