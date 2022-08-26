using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private bool _applyCameraShake;

    SpecialEffects specialEffects;
    AnimationManager animationManager;
    CameraShake cameraShake;
    bool playerIsDead = false, enemyIsDead = false;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

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
            ShakeCamera();
            damageDealer.Hit();
        }
    }


    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DeathEffects();
        }
    }

    private void DeathEffects()
    {
        if (specialEffects != null && !enemyIsDead)
        {
            specialEffects.PlayEnemyExplosion();
            enemyIsDead = true;
            Destroy(gameObject);
        }
        if (animationManager != null && !playerIsDead)
        {
            animationManager.PlayPlayerDeathAnimation();
            playerIsDead = true;
            Destroy(gameObject, 1f);
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && _applyCameraShake)
        {
            cameraShake.Play();
        }
    }

}
