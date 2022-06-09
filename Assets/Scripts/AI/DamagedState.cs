using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class DamagedState : BaseState
    {
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range
        )
        {
            throw new System.NotImplementedException();
            //Play Hurt Animation
        }

        public override void Update(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player
        )
        {
            throw new System.NotImplementedException();
            //check if Animation ended
            //Proceed to Idle state
        }
    }
}
