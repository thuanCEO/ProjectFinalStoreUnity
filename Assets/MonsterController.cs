using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f;
    public float chaseRange = 5f;
    public float wanderRadius = 5f;
    public float minIdleTime = 1f;
    public float maxIdleTime = 3f;

    private Vector3 initialPosition;
    private Vector3 wanderPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isChasing = false;
    private bool isReturning = false;
    private bool isIdle = false;
    private float returnTimer = 0f;
    private float idleTimer = 0f;
    private float currentIdleTime = 0f;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetNewIdleTime();
    }

    void Update()
    {
        if (target != null && Vector3.Distance(transform.position, target.position) <= chaseRange)
        {
            isChasing = true;
            isReturning = false;
            isIdle = false;
            returnTimer = 0f;
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);
            FlipSprite(target.position - transform.position);
        }
        else
        {
            if (isChasing)
            {
                returnTimer += Time.deltaTime;
                if (returnTimer >= 2f)
                {
                    isChasing = false;
                    isReturning = true;
                    isIdle = true;
                    SetNewIdleTime();
                    animator.SetBool("isWalking", true);
                }
            }
            if (isReturning)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
                if (transform.position == initialPosition)
                {
                    isReturning = false;
                    animator.SetBool("isWalking", false);
                }
            }
            else
            {
                if (isIdle)
                {
                    idleTimer += Time.deltaTime;
                    if (idleTimer >= currentIdleTime)
                    {
                        isIdle = false;
                        idleTimer = 0f;
                        wanderPoint = GetRandomPointInCircle(initialPosition, wanderRadius);
                        animator.SetBool("isWalking", true);
                    }
                    else
                    {
                        animator.SetBool("isWalking", false);
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, wanderPoint) <= 0.1f)
                    {
                        isIdle = true;
                        SetNewIdleTime();
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, wanderPoint, moveSpeed * Time.deltaTime);
                        animator.SetBool("isWalking", true);
                        FlipSprite(wanderPoint - transform.position);
                    }
                }
            }
        }
    }


    void SetNewIdleTime()
    {
        currentIdleTime = Random.Range(minIdleTime, maxIdleTime);
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
