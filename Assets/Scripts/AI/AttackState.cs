using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class AttackState : BaseState
    {
        IEnemyAttack _attacker;
        IAnimationManager _animationManager;
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animationManager,
            IEnemyAttack _enemyAttack
        )
        {
            control.currentState = "Attacking";
            _attacker = _enemyAttack;
            _animationManager = animationManager;

            //seek player
            //Look at player

            _animationManager.Attack();
            nav.destination = control.transform.position;
            _attacker.Attack();
        }

        public override void Update(
            EnemeyBehaviorControl control
        )
        {
            
        }
    }
}
