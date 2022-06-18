using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class DeadState : BaseState
    {
        IAnimationManager _animator;

        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animationManager,
            IEnemyAttack _enemyAttack
        )
        {
            
        }

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
        ) { }

        public override void Update(EnemeyBehaviorControl control) { }
    }
}
