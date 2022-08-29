using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayPlayerDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Death");
        }
    }

    public void PlayPlayerHitAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("GotHit");
        }
    }

}
