using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Heal(20);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not have negative Damage");
        }

        this.health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not have negative Healing");
        }

        if (health + amount <= MAX_HEALTH)
        {
            health += amount;
        }
        else
        {
            health = MAX_HEALTH;
        }
    }
    public void Die()
    {
        
        UnityEngine.Debug.Log("Die!!!!");
        Destroy(gameObject);
    }
}
