using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Player Shooting")]
    [SerializeField] private AudioClip _playerShootingClip;
    [SerializeField] [Range(0f, 1f)] private float _playerShootingVolume = 1f;

    [Header("Player Death Sound")]
    [SerializeField] private AudioClip _playerDeathClip;
    [SerializeField] [Range(0f, 1f)] private float _playerDeathVolume = 1f;

    [Header("Enemy Shooting")]
    [SerializeField] private AudioClip _enemyShootingClip;
    [SerializeField] [Range(0f, 1f)] private float _enemyShootingVolume = 1f;

    [Header("Enemy Death Sound")]
    [SerializeField] private AudioClip _enemyDeathClip;
    [SerializeField] [Range(0f, 1f)] private float _enemyDeathVolume = 1f;

    public void PlayPlayerShootingClip()
    {
        PlayClip(_playerShootingClip, _playerShootingVolume);
    }

    public void PlayPlayerDeathClip()
    {
        PlayClip(_playerDeathClip, _playerDeathVolume);
    }

    public void PlayEnemyShootingClip()
    {
        PlayClip(_enemyShootingClip, _enemyShootingVolume);
    }

    public void PlayEnemyDeathClip()
    {
        PlayClip(_enemyDeathClip, _enemyDeathVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
