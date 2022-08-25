using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    //[SerializeField] AnimationClip playerDeath;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void PlayPlayerDeathAnimation()
    {
        //if (playerDeath != null)
        //{
        //anim.Play("playerDeath", 0, 0.0f);
        //}
        if (animator != null)
        {
            animator.SetTrigger("Death");
            Debug.Log("Death animation condition is working");
        }
    }

}
