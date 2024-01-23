using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {           
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
    public void EnableAttackArea()
    {
        gameObject.SetActive(true);
    }

    public void DisableAttackArea()
    {
        gameObject.SetActive(false);
    }
}
