using System;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int CurrentHealth { get; private set; }
    public HealthBar healthBar;
    private Animator animator;
    private Rigidbody2D rb;

    private LevelManage levelManager;

    private bool canHeal = true; 
    private float healCooldown = 5;
    private float lastHealTime;
    private bool isWalking;
    private int maxHealUses = 3; 
    private int healUsesLeft;

    public TMP_Text HealUseLeft;

    private void Start()
    {
        if(SaveHealth.flag)
        {
            SaveHealth.totalHealth = maxHealth;
            SaveHealth.flag = false;
        }
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManage>();
        

        if (healthBar != null)
            healthBar.UpdateBar(SaveHealth.totalHealth, maxHealth);
        lastHealTime = Time.time;
        healUsesLeft = maxHealUses;
        UpdateHealUsesLeftUI();
    }

    private void Update()
    {
        if (!IsDead() && Input.GetKeyDown(KeyCode.L) && canHeal && healUsesLeft > 0)
        {
            if (Time.time - lastHealTime >= healCooldown)
            {
                Heal(10);
                lastHealTime = Time.time;
                healUsesLeft--;
                UpdateHealUsesLeftUI();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not have negative Damage");
        }
        SaveHealth.totalHealth -= amount;

        if (SaveHealth.totalHealth <= 0)
        {
            SaveHealth.totalHealth = 0;
            Die();
        }
        if (healthBar != null)
            healthBar.UpdateBar(SaveHealth.totalHealth, maxHealth);
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
    public void Respawn()
    {
        SaveHealth.totalHealth = maxHealth;
        isWalking = false;
        animator.SetBool("IsMoving", isWalking);
        animator.ResetTrigger("Death");
        animator.SetTrigger("Idle");
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (healthBar != null)
            healthBar.UpdateBar(SaveHealth.totalHealth, maxHealth);
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException("Can not heal by a negative amount");
        }
        SaveHealth.totalHealth += amount;
        if (SaveHealth.totalHealth > maxHealth)
        {
            SaveHealth.totalHealth = maxHealth;
        }
        if (healthBar != null)
            healthBar.UpdateBar(SaveHealth.totalHealth, maxHealth);
    }
    bool IsDead()
    {
        return SaveHealth.totalHealth <= 0;
    }
    private void UpdateHealUsesLeftUI()
    {
        if (HealUseLeft != null)
        {
            HealUseLeft.text =  healUsesLeft.ToString();
        }
    }
}
