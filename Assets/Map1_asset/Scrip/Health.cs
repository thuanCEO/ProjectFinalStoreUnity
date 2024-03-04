using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth { get; private set; }
    public HealthBar healthBar;
    private Animator animator;
    private Rigidbody2D rb;

    private LevelManage levelManager;

    private void Start()
    {
        CurrentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManage>(); 

        if (healthBar != null)
            healthBar.UpdateBar(CurrentHealth, maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not have negative Damage");
        }
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        if (healthBar != null)
            healthBar.UpdateBar(CurrentHealth, maxHealth);
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
        Debug.Log("Die!!!!");

        if (levelManager != null)
        {
            levelManager.ShowDeathPanel();
        }
    }
}
