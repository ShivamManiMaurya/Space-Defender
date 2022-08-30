using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyExplosion;

    public void PlayEnemyExplosion()
    {
        if (enemyExplosion != null)
        {
            ParticleSystem instance = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
