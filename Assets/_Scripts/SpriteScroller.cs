using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 _moveSpeed;

    Vector2 offset;
    Material material;


    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        offset = _moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
