using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilEnemy : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] TMPro.TextMeshProUGUI lifeText;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider energyBar;
    [SerializeField] GameObject HitBox;
    [SerializeField] GameObject victoryPanel;


    private float currentHP;
    private float currentEnergy;
    // Start is called before the first frame update
    void Start()
    {
        enemy.enemyLife = 3;
        lifeText.text = enemy.enemyLife.ToString();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite = enemy.enemySprite;
        animator.runtimeAnimatorController = enemy.enemyanimator;

        rb = GetComponent<Rigidbody2D>();

        //HP
        healthBar.maxValue = enemy.enemyHealth;
        currentHP = enemy.enemyHealth;
        energyBar.maxValue = enemy.enemyEnergy;
        currentEnergy = enemy.enemyEnergy;
    }


    // Update is called once per frame
    void Update()
    {

        if (currentEnergy < 100)
        {
            currentEnergy += 30f * Time.deltaTime;
            energyBar.value = currentEnergy;
        }
        if (currentHP < 100)
        {
            currentHP += 1f * Time.deltaTime;
            healthBar.value = currentHP;
        }
        if (currentHP <= 0)
        {
            enemy.enemyLife--;
            currentHP = enemy.enemyHealth;
            healthBar.value = currentHP;
            lifeText.text = enemy.enemyLife.ToString();
        }
        if (enemy.enemyLife == 0)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
        RaycastHit2D hit = Physics2D.Raycast(HitBox.transform.position, Vector3.left, 1f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" && currentEnergy > 20)
            {
                animator.Play(enemy.punch.name);
                currentEnergy -= 20;
                energyBar.value = currentEnergy;
            }
        }
        else
        {
            rb.velocity = new Vector2(-2, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            currentHP -= 10;
            healthBar.value = currentHP;
            rb.AddForce(new Vector2(10, 0), ForceMode2D.Impulse);
        }
    }
}
