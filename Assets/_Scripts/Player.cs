using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _paddingLeft, _paddingRight;
    [SerializeField] private float _paddingTop, _paddingBottom;

    private Vector2 _rawInput;
    Vector2 _minBound, _maxBound;

    private void Start()
    {
        InitBound();
    }

    void Update()
    {
        Move();
    }

    private void InitBound()
    {
        Camera mainCamera = Camera.main;
        _minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
        
    private void Move()
    {
        Vector2 delta = (_rawInput * _moveSpeed * Time.deltaTime);
        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, _minBound.x + _paddingLeft, _maxBound.x - _paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, _minBound.y + _paddingBottom, _maxBound.y - _paddingTop)
        };
        transform.position = newPos;

    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
        Debug.Log(_rawInput);
    }

}
