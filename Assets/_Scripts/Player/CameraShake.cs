using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 1f;
    [SerializeField] private float _shakeMagnitude = 0.5f;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }


    public void Play()
    {
        StartCoroutine(Shake());
        
    }

    IEnumerator Shake()
    {
        float elapseTime = 0;
        while (elapseTime < _shakeDuration)
        {
            transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
            elapseTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = _initialPosition;
        

        
    }

}
