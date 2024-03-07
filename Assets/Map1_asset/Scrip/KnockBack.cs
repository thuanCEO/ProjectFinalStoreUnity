using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D Enemy = collision.gameObject.GetComponent<Rigidbody2D>();
            if (Enemy != null)
            {
                Enemy.isKinematic = false;
                Vector2 difference = Enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(Enemy));
            }
        }
    }
    private IEnumerator KnockCo(Rigidbody2D Enemy)
    {
        if (Enemy != null) // Ki?m tra xem ??i t??ng có t?n t?i không
        {
            yield return new WaitForSeconds(knockTime);
            if (Enemy != null) // Ki?m tra l?i sau khi ch?
            {
                Enemy.velocity = Vector2.zero;
                Enemy.isKinematic = true;
            }
        }
    }
}
