using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed =  5f;
    
    private Rigidbody2D rb;

    public Animator animator;

    public float x, y;
    private bool isWalking;
    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(x, y, 0f).normalized;
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;

        if (x != 0  || y != 0)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
            animator.SetFloat("Speed", moveDir.sqrMagnitude);
            if(!isWalking)
            {
                isWalking = true;
                animator.SetBool("IsMoving", isWalking);              
            }
        }
        else
        {
            if(isWalking)
            {
                isWalking = false;
                animator.SetBool("IsMoving", isWalking);
                StopMoving();
            }
        }

        moveDir = new Vector3(x, y).normalized;
    }

    private void fixUpdate()
    {
        
    }

    private void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }
}
