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
            IAnimationManager animator
        );
        public abstract void Update(
            EnemeyBehaviorControl control
        );
    }
}
