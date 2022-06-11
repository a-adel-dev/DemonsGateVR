using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class DeadState : BaseState
    {
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animationManager,
            IEnemyAttack _enemyAttack
        )
        {
            throw new System.NotImplementedException();
            //Play Death Animation
        }

        public override void Update(EnemeyBehaviorControl control)
        {
            throw new System.NotImplementedException();
            //Raise enemy death events
        }
    }
}
