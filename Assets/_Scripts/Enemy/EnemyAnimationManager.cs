using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayEnemyHitAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("EnemyGotHit");
        }
    }
}
