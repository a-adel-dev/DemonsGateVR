using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Interfaces
{
    public interface IAnimationManager
    {
        bool IsAnimationFinished();
        void SeekPlayer();
        void Spawn();

        void Attack();
        void TakeDamage();
        void Die();
        void EnableAnimator();
        void DisableAnimator();
    }
}
