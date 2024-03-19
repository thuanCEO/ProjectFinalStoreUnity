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
    private bool isDamageBoosted = false;
    private int baseDamage = 3;
    private int damageBoost = 0; 

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (isAttacking && Time.time - lastAttackTime >= attackCooldown)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();

            if (health != null)
            {

                int totalDamage = baseDamage + damageBoost;

                health.Damage(totalDamage);
                lastAttackTime = Time.time;
            }
        }
    }
    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    public IEnumerator BoostDamageForDuration(float duration)
    {
        damageBoost += 5;

        UnityEngine.Debug.Log("Current Damage: " + (baseDamage + damageBoost));

        yield return new WaitForSeconds(duration);

        damageBoost -= 5;

        UnityEngine.Debug.Log("Damage Restored: " + (baseDamage + damageBoost));
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
