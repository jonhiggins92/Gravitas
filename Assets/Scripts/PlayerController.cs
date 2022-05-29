using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Animator animator;
    private int gravSwitch = 1;
    public float jumpForce = 27;
    private BoxCollider2D boxCollider;
    public bool groundCheck;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        //flips player facing direction
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        if (isGrounded() == true)
            groundCheck = true;
        else if (isGrounded() == false)
            groundCheck = false;

        //jump with spacebar or 'y' button
        if (Input.GetButtonDown("Jump") && isGrounded() == true)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * gravSwitch);

        //reverse gravity with left control or 'a' button
        if (Input.GetButtonDown("Fire1"))
            ReverseGravity();

        //gets speed for animator
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            
    }

    private void ReverseGravity()
    {
        if (rb.gravityScale == 10)
        {
            rb.gravityScale = -10;
            animator.SetBool("Switch", true);
            gravSwitch = -1;
        }
        else if (rb.gravityScale == -10)
        {
            rb.gravityScale = 10;
            animator.SetBool("Switch", false);
            gravSwitch = 1;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f * gravSwitch, groundLayer);
        return raycastHit.collider != null;
    }


}
