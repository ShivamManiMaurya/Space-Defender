using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private bool _applyCameraShake;
    [SerializeField] private int _enemyDiePoints = 100;

    SpecialEffects specialEffects;
    AnimationManager animationManager;
    EnemyAnimationManager enemyAnimationManager;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    UIDisplay uiDisplay;
    LevelManager levelManager;
    bool playerIsDead = false, enemyIsDead = false;


    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        uiDisplay = FindObjectOfType<UIDisplay>();
        levelManager = FindObjectOfType<LevelManager>();
        specialEffects = GetComponent<SpecialEffects>();
    }

    private void Start()
    {
        animationManager = GetComponentInChildren<AnimationManager>();
        enemyAnimationManager = GetComponentInChildren<EnemyAnimationManager>();
        uiDisplay.UpdateHealth();
        uiDisplay.UpdateScore();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null && collision.CompareTag("PlayerProjectile"))
        {
            if (enemyAnimationManager != null)
            {
                enemyAnimationManager.PlayEnemyHitAnimation();
            }
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }

        if (damageDealer != null && collision.CompareTag("EnemyProjectile"))
        {
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            damageDealer.Hit();
        }
        
        if (collision.CompareTag("Player"))
        {
            //if (enemyAnimationManager != null)
            //{
            //    enemyAnimationManager.PlayEnemyHitAnimation();
            //}
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            EnemyDeathWhenCollision();
        }
    }

    private void EnemyDeathWhenCollision()
    {
        Debug.Log("takar ka chala");
        specialEffects.PlayEnemyExplosion();
        audioPlayer.PlayEnemyDeathClip();
        scoreKeeper.ModifyScore(_enemyDiePoints);
        uiDisplay.UpdateScore();
        Debug.Log("Baad ka code chala");
        Destroy(gameObject);
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
            Debug.Log("Sabkuch chala");
            specialEffects.PlayEnemyExplosion();
            enemyIsDead = true;
            audioPlayer.PlayEnemyDeathClip();
            scoreKeeper.ModifyScore(_enemyDiePoints);
            uiDisplay.UpdateScore();
            Destroy(gameObject);
            
        }
        if (animationManager != null && !playerIsDead)
        {
            animationManager.PlayPlayerDeathAnimation();
            playerIsDead = true;
            audioPlayer.PlayPlayerDeathClip();
            levelManager.LoadGameOver();
            Destroy(gameObject, 1f);
        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && _applyCameraShake)
        {
            cameraShake.Play();
            uiDisplay.UpdateHealth();
            animationManager.PlayPlayerHitAnimation();
        }
    }

}
