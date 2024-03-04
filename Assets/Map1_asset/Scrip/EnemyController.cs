using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    GameObject playerGameObject;
    Health playerHealth;
    public int minDamage;
    public int maxDamage;
    public float damageInterval;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerGameObject = collision.gameObject;
            playerHealth = playerGameObject.GetComponent<Health>();
            InvokeRepeating("DamagePlayer", 0, damageInterval);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerGameObject = null;
            playerHealth = null;
            CancelInvoke("DamagePlayer");
        }
    }
    void DamagePlayer()
    {
        Debug.Log("DamagePlayer called");
        int damageP = UnityEngine.Random.Range(minDamage, maxDamage);
        Debug.Log("Player take Damage" + damageP);
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageP);
        }
    }
    
}
