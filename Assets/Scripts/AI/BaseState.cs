using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public abstract class BaseState
    {
        public abstract void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animator,
            IEnemyAttack _enemyAttack
        );
        public abstract void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
            );
        public abstract void Update(EnemeyBehaviorControl control);
    }
}
