using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    
    [SerializeField] int maxHealth ;
    int currentHealth;
    public HealthBar healthBar;
    //public GameObject DamageText;


    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.UpdateBar(currentHealth, maxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(20);
        }
    }
    

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not have negative Damage");
        }
        //Instantiate(DamageText, transform.position, Quaternion.identity);
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        if (healthBar != null)
            healthBar.UpdateBar(currentHealth, maxHealth);

    }


    public void Die()
    {
        
        UnityEngine.Debug.Log("Die!!!!");
        Destroy(gameObject);
    }
}
