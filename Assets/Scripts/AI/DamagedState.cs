using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class DamagedState : BaseState
    {
        IAnimationManager _animator;
        BaseState _previousState;

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animationManager,
            BaseState previousState
        )
        {
            //Play Hurt Animation
            animationManager.TakeDamage();
        }

        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animator,
            IEnemyAttack _enemyAttack
        ) { }

        public override void Update(EnemeyBehaviorControl control)
        {
            if (_animator == null)
                return;
            if (_animator.IsAnimationFinished())
            {
                if (_previousState.GetType() == typeof(AttackState))
                {
                    control.Attack();
                }
                else
                {
                    control.SeekPlayer();
                }
                
            }
        }
    }
}
