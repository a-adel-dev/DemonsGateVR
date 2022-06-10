using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class SeekingState : BaseState
    {
        float _range;
        IAnimationManager _animator;
        NavMeshAgent _nav;
        GameObject _player;
        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animator
        )
        {
            _range = range;
            _animator = animator;
            _nav = nav;
            _player = player;
            _nav.SetDestination(_player.transform.position);
            _animator.SeekPlayer();
            control.currentState = "Seeking";

        }

        public override void Update(
            EnemeyBehaviorControl control
        )
        {
            if (_nav.remainingDistance <= _range && control.CanSeePlayer())
            {
                control.Attack();
            }
        }

        public override string ToString()
        {
            return "Spawning";
        }

    }
}
