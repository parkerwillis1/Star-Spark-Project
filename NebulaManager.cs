using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaManager : MonoBehaviour
{
    public static NebulaManager instance; // Singleton instance
    public GameObject nebulaObject; // Assign the nebula object here
    private int enemyCount; // To keep track of the number of enemies
    public ArrowIndicator arrowIndicator; // Assign this in the Inspector

    void Awake()
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

    void Start()
    {
        nebulaObject.SetActive(false); // Disable nebula object at the start
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // Count the number of enemies at the start
        Debug.Log("Initial Enemy Count: " + enemyCount); // Log the initial enemy count
    }

    public void RegisterEnemy()
    {
        enemyCount++; // Increase the enemy count when a new enemy is registered
        Debug.Log("Enemy Registered. Total Enemies: " + enemyCount); // Log the total enemy count after registering
    }

    public void EnemyDestroyed()
    {
        enemyCount--;
        Debug.Log("Enemy Destroyed. Remaining: " + enemyCount);

        if (enemyCount <= 0)
        {
            Debug.Log("All enemies destroyed. Activating Arrow.");
            arrowIndicator.ActivateArrow(); // Activate the arrow
            nebulaObject.SetActive(true); // Activate the nebula
        }
    }


    public bool IsAllEnemiesDestroyed()
    {
        return enemyCount <= 0; // Return true if all enemies are destroyed, false otherwise
    }

    private void CheckForAllEnemiesDefeated()
    {
        if (IsAllEnemiesDestroyed())
        {
            arrowIndicator.ActivateArrow();
        }
    }
}

