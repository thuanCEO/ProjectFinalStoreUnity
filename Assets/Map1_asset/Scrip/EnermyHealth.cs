using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
       
    }
    private void Die()
    {
        if(currentHealth <= 0)
        {
            UnityEngine.Debug.Log("Die!!!!");
            Destroy(gameObject);
        }
    }
}
