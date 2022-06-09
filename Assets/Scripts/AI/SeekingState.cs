using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class SeekingState : BaseState
    {
        float _range;
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range
        )
        {
            _range = range;
            nav.SetDestination(player.transform.position);
        }

        public override void Update(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player
        )
        {
            if (nav.remainingDistance <= _range && control.CanSeePlayer())
            {
                control.Attack();
            }
        }
    }
}
