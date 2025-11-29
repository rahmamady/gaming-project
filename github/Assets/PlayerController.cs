using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        float horizontal = 0;

        if (Input.GetKey(L))
            horizontal = -moveSpeed;
        else if (Input.GetKey(R))
            horizontal = moveSpeed;

        rb.velocity = new Vector2(horizontal, rb.velocity.y);

        if (sr != null)
            sr.flipX = horizontal < 0;

        if (Input.GetKeyDown(Spacebar) && grounded)
            Jump();

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Height", rb.velocity.y);
        anim.SetBool("Grounded", grounded);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
    
}
