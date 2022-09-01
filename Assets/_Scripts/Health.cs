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

        if (damageDealer != null)
        {
            if (enemyAnimationManager != null)
            {
                enemyAnimationManager.PlayEnemyHitAnimation();
            }
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
            audioPlayer.PlayEnemyDeathClip();
            scoreKeeper.ModifyScore(_enemyDiePoints);
            uiDisplay.UpdateScore();
            Destroy(gameObject);
            Debug.Log("Sabkuch chala");
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
