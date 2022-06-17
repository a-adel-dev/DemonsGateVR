
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
        animator.SetBool("idle", false);
        animator.SetBool("seeking", false);
        animator.SetTrigger("shooting");
        animator.SetBool("idle", true);
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

    public void Reload()
    {
        animator.SetTrigger("reloading");
        animator.SetBool("idle", false);
    }

    public void Idle()
    {
        animator.SetBool("seeking", false);
        animator.SetBool("idle", true);
    }
}
