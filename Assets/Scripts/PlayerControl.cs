using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    PlayerInput input;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D col;
    Animator anim;
    bool onJump = false;
    Vector2 direction;
    int life = 3;
    [SerializeField] TMPro.TextMeshProUGUI lifeText;
    [SerializeField] GameObject defeatPanel;
    [SerializeField] Slider healthBar;
    float maxHP = 100;
    float currentHP;
    int energy = 100;
    float currentEnergy;
    [SerializeField] Slider energyBar;
    bool hitAble = true;
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
        currentHP = maxHP;
        healthBar.maxValue = maxHP;
        energyBar.maxValue = energy;
        currentEnergy = energy;
        lifeText.text = life.ToString();

        input.Player.Move.performed += ctx => direction = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (currentEnergy < 100)
        {
            currentEnergy += 10f * Time.deltaTime;
            energyBar.value = currentEnergy;
        }
        if (currentHP < 100)
        {
            currentHP += 1f * Time.deltaTime;
            healthBar.value = currentHP;
        }
        if (currentHP <= 0)
        {
            life--;
            lifeText.text = life.ToString();
            currentHP = maxHP;
            healthBar.value = currentHP;
        }
        if (life <= 0)
        {
            defeatPanel.SetActive(true);
            Time.timeScale = 0;
            Invoke("GoToMenu", 3);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyHitBox")
        {
            if (hitAble == true)
            {
                currentHP -= 10;
                healthBar.value = currentHP;
                rb.AddForce(Vector2.left * 10);
            }
        }
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
        // if (direction.x != 0)
        // {
        //     sr.flipX = direction.x < 0;
        // }
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
        if (currentEnergy > 10)
        {
            anim.Play("punch");
            currentEnergy -= 10;
            energyBar.value = currentEnergy;
        }
    }
    public void Kick()
    {
        if (currentEnergy > 20)
        {
            anim.Play("kick");
            currentEnergy -= 20;
            energyBar.value = currentEnergy;
        }
    }
    public void Defend()
    {
        anim.Play("defend");
    }
    public void Hit()
    {
        hitAble = false;
    }
    public void EndHit()
    {
        hitAble = true;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
