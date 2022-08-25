using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;

    SpecialEffects specialEffects;
    AnimationManager animationManager;
    bool playerIsDead = true, enemyIsDead = true;

    private void Start()
    {
        specialEffects = GetComponent<SpecialEffects>();
        animationManager = GetComponentInChildren<AnimationManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }


    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (specialEffects != null && enemyIsDead)
            {
                specialEffects.PlayEnemyExplosion();
                enemyIsDead = false;
                Destroy(gameObject);
            }
            if (animationManager != null && playerIsDead)
            {
                animationManager.PlayPlayerDeathAnimation();
                playerIsDead = false;
                Destroy(gameObject, 1f);
            }
            
        }
    }

}
