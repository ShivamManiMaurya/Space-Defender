using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 10f;
    [SerializeField] private float _projectileLifeTime = 5f;
    [SerializeField] private float _firingRate = 1f;

    public bool isFiring;

    private Coroutine _firingCoroutine;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring)
        {
            _firingCoroutine =  StartCoroutine(FireContinuously());
        }
        else
        {
            StopCoroutine(_firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            Instantiate(_projectilePrefab, transform);
            Destroy(_projectilePrefab, _firingRate);
        }
    }

}
