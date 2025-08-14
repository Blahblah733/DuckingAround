using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageDealt = 20;  // Damage to deal
    public Collider2D attackCollider;  // The collider representing the attack hitbox

    void Update()
    {
        // Detect left-click input
        if (Input.GetMouseButtonDown(0))  // 0 for left-click
        {
            // Activate the attack hitbox temporarily (or trigger attack logic)
            if (attackCollider != null)
            {
                attackCollider.enabled = true; // Enable the collider to trigger
            }

            // Optionally, deactivate it again after a short delay to simulate the attack duration
            Invoke("DisableAttackCollider", 0.1f);  // Adjust timing as needed
        }
    }

    private void DisableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;  // Disable the collider after the attack
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        EnemyLogic enemyLogic = other.GetComponent<EnemyLogic>();
        if (enemyLogic != null)
        {
            // Apply damage to the enemy
            enemyLogic.Damage(damageDealt);
        }
    }
}


