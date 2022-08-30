using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayPlayerBulletAnimation()
    {
        if (animator != null)
        {
            //animator.SetTrigger("BulletFired");
        }
    }
}
