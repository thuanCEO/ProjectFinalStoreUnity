using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public AttackArea attackArea;
    private int enemyKilledCount = 0;
    private int extraDamage = 0;

    void Start()
    {
        attackArea = GetComponent<AttackArea>();
    }

    void OnEnable()
    {
        foreach (EnemyHealth enemyHealth in FindObjectsOfType<EnemyHealth>())
        {
            enemyHealth.OnDeath.AddListener(IncrementEnemyKilledCount);
        }
    }

    void OnDisable()
    {
        foreach (EnemyHealth enemyHealth in FindObjectsOfType<EnemyHealth>())
        {
            enemyHealth.OnDeath.RemoveListener(IncrementEnemyKilledCount);
        }
    }

    void IncrementEnemyKilledCount()
    {
        enemyKilledCount++;
        UpdateDamageMultiplier();
        Debug.Log("Enemy killed count: " + enemyKilledCount);
    }

    private void UpdateDamageMultiplier()
    {
        if (attackArea != null)
        {
            if (enemyKilledCount >= 5 && enemyKilledCount < 10)
            {
                extraDamage = 1;
            }
            else if (enemyKilledCount >= 10)
            {
                extraDamage = 2;
            }

            int newDamage = 3 + extraDamage;
            attackArea.SetDamage(newDamage);
            Debug.Log("New damage: " + newDamage);
        }
    }
}
