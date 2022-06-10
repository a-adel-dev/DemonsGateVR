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
    }

    public void Spawn()
    {
        
    }
}
