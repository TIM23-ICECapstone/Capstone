using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "NewEnemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    [Range(0, 100)]
    public int enemyLife;
    public Sprite enemySprite;
    [Range(0, 100)]
    public int enemyHealth;
    [Range(0, 100)]
    public int enemyEnergy;
    public int enemyDamage;
    public RuntimeAnimatorController enemyanimator;
    public AnimationClip idle;
    public AnimationClip punch;
    public AnimationClip kick;
    public AnimationClip walk;
    public AnimationClip die;
    public AnimationClip victory;

}
