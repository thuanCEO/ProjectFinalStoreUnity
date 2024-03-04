using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f;
    public float chaseRange = 5f;
    public float wanderRadius = 5f;

    private Vector3 initialPosition;
    private Vector3 wanderPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetNewWanderPoint();
    }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= chaseRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            FlipSprite(target.position - transform.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, wanderPoint) <= 0.1f)
            {
                SetNewWanderPoint();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wanderPoint, moveSpeed * Time.deltaTime);
                animator.SetBool("isWalking", true);
                FlipSprite(wanderPoint - transform.position);
            }
        }
    }

    void SetNewWanderPoint()
    {
        wanderPoint = GetRandomPointInCircle(initialPosition, wanderRadius);
    }

    Vector3 GetRandomPointInCircle(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2); // Random angle in radians
        float x = center.x + Mathf.Cos(angle) * radius;
        float z = center.z + Mathf.Sin(angle) * radius;
        return new Vector3(x, center.y, z);
    }

    void FlipSprite(Vector3 direction)
    {
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        else if (direction.x < 0)
            spriteRenderer.flipX = true;
    }
}
