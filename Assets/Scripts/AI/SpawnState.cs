using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class SpawnState : BaseState
    {
        float _range;
        IAnimationManager _animator;

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
        ) { }

        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animator,
            IEnemyAttack _enemyAttack
        )
        {
            _range = range;
            _animator = animator;
            _animator.Spawn();
            control.currentState = "Spawning";
            
        }

        public override void Update(EnemeyBehaviorControl control)
        {
            if (_animator == null)
                return;
            if (_animator.IsAnimationFinished())
            {
                //Debug.Log("Animation finished");
                control.SeekPlayer(_range);
            }
        }

        public override string ToString()
        {
            return "Spawning";
        }
    }
}
