using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    public int damageDealt = 20;  // Damage to deal
    public Collider2D attackCollider;  // The collider representing the attack hitbox
    public LayerMask enemyHitboxLayer; // The layer the enemy hitbox is on
    public float attackDuration = 0.1f; // How long the attack window is

    private bool isAttacking = false;

    void Update()
    {
        // Detect left-click input
        if (Input.GetMouseButtonDown(0))  // 0 for left-click
        {
            StartAttack();
        }
    }


    void StartAttack()
    {
        isAttacking = true;

        // Add Attack Animation Here

        // End the Attack Window after attackDuration Seconds
        Invoke(nameof(EndAttack), attackDuration);
    }

    void EndAttack()
    {
        isAttacking = false;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking)
        {
            if (((1 << other.gameObject.layer) & enemyHitboxLayer) != 0)
            {
                // Check if the collider is the attack collider
                EnemyDamageZone dmgZone = other.GetComponent<EnemyDamageZone>();
                if (dmgZone != null)
                {
                    dmgZone.ApplyDamage(damageDealt);

                    isAttacking=false;
                }
            }
        }
    }
}



