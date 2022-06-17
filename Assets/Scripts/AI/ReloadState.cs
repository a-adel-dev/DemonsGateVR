using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class ReloadState : BaseState
    {
        private IAnimationManager _animator;
        public override void EnterState(EnemeyBehaviorControl control, NavMeshAgent nav, GameObject player, float range,
            IAnimationManager animator, IEnemyAttack _enemyAttack)
        {
            
        }

        public override void EnterState(EnemeyBehaviorControl control, IAnimationManager animator,
            BaseState previousState)
        {
            control.currentState = "Reloading";
            _animator = animator;
            animator.Reload();
        }

        public override void Update(EnemeyBehaviorControl control)
        {
            if (_animator == null)
                return;
            if (_animator.IsAnimationFinished())
            {
                //Debug.Log("Animation finished");
                control.Attack();
            }
        }
    }
}