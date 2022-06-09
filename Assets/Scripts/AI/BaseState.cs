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
            float range
        );
        public abstract void Update(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player
        );
    }
}
