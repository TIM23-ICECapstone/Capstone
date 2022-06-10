using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilEnemy : MonoBehaviour
{
    public Enemy enemy;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.sprite = enemy.enemySprite;
        animator.runtimeAnimatorController = enemy.enemyanimator;
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(enemy.idle.name);
    }
}
