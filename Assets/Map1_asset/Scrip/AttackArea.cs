using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    
    private bool isAttacking = false;
    private float attackCooldown = 0.5f;
    private float lastAttackTime;
    private void OnTriggerEnter2D(Collider2D collider)
    {
       // UnityEngine.Debug.Log("Trigger Entered!");

        if (isAttacking && Time.time - lastAttackTime >= attackCooldown)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();

            if (health != null)
            {
                health.Damage(damage);
                lastAttackTime = Time.time;
            }
        }
    }

    public void EnableAttackArea()
    {
        isAttacking = true;
        gameObject.SetActive(true);
    }

    public void DisableAttackArea()
    {
        isAttacking = false;
        gameObject.SetActive(false);
    }
}
