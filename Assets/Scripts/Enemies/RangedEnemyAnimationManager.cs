using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonsGate.Interfaces;

public class RangedEnemyAnimationManager : MonoBehaviour, IAnimationManager
{
    Animator animator;
    AnimatorStateInfo animatorStateInfo;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public bool IsAnimationFinished()
    {
        float Ntime;

        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        Ntime = animatorStateInfo.normalizedTime;

        return Ntime > 1.0f;
    }

    public void SeekPlayer()
    {
        animator.SetBool("seeking", true);
        animator.SetBool("shooting", false);
    }

    public void Spawn()
    {
        
    }

    public void Attack()
    {
        animator.SetBool("seeking", false);
        animator.SetBool("shooting", true);
    }

    public void TakeDamage()
    {
        animator.SetTrigger("damage");
    }

    public void Die()
    {
        animator.SetTrigger("death");
    }

    public void EnableAnimator()
    {
        if (animator != null)
        {
            animator.enabled = true;
        }
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }
}
