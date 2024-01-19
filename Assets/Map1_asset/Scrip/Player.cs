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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
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
}
