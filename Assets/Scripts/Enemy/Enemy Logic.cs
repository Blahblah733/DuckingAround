using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int enemyHealth = 100;

    // Change this to accept a float instead of an int
    public void Damage(float damageAmount)
    {
        enemyHealth -= Mathf.RoundToInt(damageAmount);  // Convert float to int for health

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);  // Destroy the enemy if health reaches 0
        }
    }
}

