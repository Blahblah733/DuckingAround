using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageZone : MonoBehaviour
{
    private EnemyLogic enemyLogic;

    private void Awake()
    {
        enemyLogic = GetComponentInParent<EnemyLogic>();
    }

    public void ApplyDamage(float damageAmount)
    {
        if (enemyLogic != null)
        {
            enemyLogic.Damage(damageAmount);
        }
    }
}
