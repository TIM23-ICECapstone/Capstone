using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilEnemy : MonoBehaviour
{
    public Enemy enemy;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] Slider healthBar;


    private float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite = enemy.enemySprite;
        animator.runtimeAnimatorController = enemy.enemyanimator;

        //HP
        healthBar.maxValue = enemy.enemyHealth;
        currentHP = enemy.enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "HitBox")
    //     {
    //         //animator.Play(enemy.punch.name);
    //         currentHP -= 30;
    //         healthBar.value = currentHP;
    //     }
    //     print(other.collider.tag);
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "HitBox")
        {
            //animator.Play(enemy.punch.name);
            currentHP -= 30;
            healthBar.value = currentHP;
        }
        print(other.tag);
    }
}
