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
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    bool playerIsDead = false, enemyIsDead = false;


    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        specialEffects = GetComponent<SpecialEffects>();
        animationManager = GetComponentInChildren<AnimationManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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
            audioPlayer.PlayEnemyDeathClip();
            scoreKeeper.ModifyScore(_enemyDiePoints);
            Destroy(gameObject);
        }
        if (animationManager != null && !playerIsDead)
        {
            animationManager.PlayPlayerDeathAnimation();
            playerIsDead = true;
            audioPlayer.PlayPlayerDeathClip();
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
