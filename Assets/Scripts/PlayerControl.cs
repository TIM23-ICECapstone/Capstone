using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerControl : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D col;
    Animator anim;
    bool onJump = false;
    Vector2 direction;
    [SerializeField] float speed = 5f;
    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        input.Player.Move.performed += ctx => direction = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        Jump();
    }
    private void Move()
    {
        if (onJump)
        {
            return;
        }
        if (direction.x != 0)
        {
            sr.flipX = direction.x < 0;
        }
        anim.SetBool("walk", direction.x != 0);
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
    }
    public void Jump()
    {

        if (!IsGrounded())
            return;
        onJump = !IsGrounded();
        if (direction.y > 0.2)
            rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        anim.SetBool("jump", onJump);
        return;
    }
    public void Punch()
    {
        anim.Play("punch");
    }
    public void Kick()
    {
        anim.Play("kick");
    }
    public void Defend()
    {
        anim.Play("defend");
    }
}
