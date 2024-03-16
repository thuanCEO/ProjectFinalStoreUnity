using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public GameObject damageText;
    public TextMeshPro popupText;
    public UnityEvent OnDeath;
    // Start is called before the first frame update
    [SerializeField] EnemyHealBar enemyHealBar;
    private void Awake()
    {
        enemyHealBar = GetComponentInChildren<EnemyHealBar>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        if(enemyHealBar != null)
        {

            enemyHealBar.UpdateEnemyHealthBar(currentHealth, maxHealth);
        }
       

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
        Instantiate(damageText, transform.position, Quaternion.identity);
        popupText.text = amount.ToString();
        currentHealth -= amount;
        if (enemyHealBar != null)
        {

            enemyHealBar.UpdateEnemyHealthBar(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("Enemy died!");
        OnDeath.Invoke();
        Destroy(gameObject);
    }
}
