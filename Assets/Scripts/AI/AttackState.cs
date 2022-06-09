using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class AttackState : BaseState
    {
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range
        )
        {
            throw new System.NotImplementedException();
            //seek player
            //Look at player
        }

        public override void Update(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player
        )
        {
            throw new System.NotImplementedException();
            //Attack Player
            //Update Enemy Health
        }
    }
}
