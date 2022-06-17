using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class IdleState : BaseState
    {
        IAnimationManager _animator;

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
        ) { }

        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animator,
            IEnemyAttack _enemyAttack
        )
        {
            _animator = animator;
            control.currentState = "Idle";
            _animator.Idle();

        }

        public override void Update(EnemeyBehaviorControl control)
        {
        }

        public override string ToString()
        {
            return "Idle";
        }
    }
}