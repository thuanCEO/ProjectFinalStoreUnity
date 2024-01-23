using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public Vector3 moveInput;
    private Rigidbody2D rb;
    private bool isWalking;
    private bool isAttacking = false;
    private AttackArea attackArea;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).GetComponent<AttackArea>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        attackArea.DisableAttackArea();
        GameObject playerContainer = new GameObject("PlayerContainer");

        transform.parent = playerContainer.transform;

        if (animator == null)
        {
            animator = playerContainer.AddComponent<Animator>();
        }

        if (rb == null)
        {
            rb = playerContainer.AddComponent<Rigidbody2D>();
        }

        DontDestroyOnLoad(playerContainer);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isAttacking)
        {
            isAttacking = true;
            animator.SetBool("IsAttacking", isAttacking);
            attackArea.EnableAttackArea();
        }
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;


        if (moveInput.x != 0 || moveInput.y != 0)
        {

            animator.SetFloat("X", moveInput.x);
            animator.SetFloat("Y", moveInput.y);
            if (!isWalking)
            {
                isWalking = true;
                animator.SetBool("IsMoving", isWalking);
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    animator.SetBool("IsMoving", isWalking);
                    StopMoving();
                }
            }
            
        }
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
    public void AttackFinished()
    {
        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetTrigger("AttackFinished");
        attackArea.DisableAttackArea();

    }
}
