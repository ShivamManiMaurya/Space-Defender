using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private float _projectileLifeTime = 5f;
    [SerializeField] private float _firingRate = 1f;

    [Header("AI")]
    [SerializeField] private bool isAI;
    [SerializeField] private float _baseFiringRate, _firingRateVariance, _minimumFiringRate = 1;

    [HideInInspector] public bool isFiring;

    private Coroutine _firingCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        // If isAI is true means this script is active on our enemies so firing is automatic
        if (isAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && _firingCoroutine == null)
        {
            _firingCoroutine =  StartCoroutine(FireContinuously());
        }
        else if (!isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = InstantiatingProjectile();

            // Passing velocity to our projectile
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * _projectileSpeed;
            }

            // Destroying our projectile so it will get destroyed after some time
            Destroy(instance, _projectileLifeTime);

            if (isAI)
            {
                // Provoiding random firing rate for Enemy
                yield return new WaitForSeconds(RandomFiringRateEnemy());
            }
            else
            {
                // Provoiding firing rate for Player
                yield return new WaitForSeconds(_firingRate);
            }
        }

    }

    // Method for Randomizing the Firing rate of enemy
    private float RandomFiringRateEnemy()
    {
        float enemyFiringRate = Random.Range(_baseFiringRate - _firingRateVariance,
                                             _baseFiringRate + _firingRateVariance);
        enemyFiringRate = Mathf.Clamp(enemyFiringRate, _minimumFiringRate, float.MaxValue);
        return enemyFiringRate;
    }

    private GameObject InstantiatingProjectile()
    {
        GameObject instance;

        if (isAI)
        {
            // Here the projectile is rotated 180 degrees so the projectile sprite is seen rotated
            instance = Instantiate(_projectilePrefab, transform.position,
                                            Quaternion.Euler(0, 0, 180));
            audioPlayer.PlayEnemyShootingClip();
        }
        else
        {
            // Here no rotation by Quaternion.identity so the projetile is not rotated
            instance = Instantiate(_projectilePrefab, transform.position,
                                            Quaternion.identity);
            audioPlayer.PlayPlayerShootingClip();
        }

        return instance;
    }

}
