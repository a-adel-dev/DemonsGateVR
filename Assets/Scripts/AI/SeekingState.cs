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
            _nav = nav;
            _player = player;
            _nav.SetDestination(_player.transform.position);
            _animator.SeekPlayer();
            control.WeaponIk.SetTargetTransform(player.GetComponent<PlayerTarget>().Target.transform);
            control.currentState = "Seeking";
        }

        public override void Update(EnemeyBehaviorControl control)
        {
            if (_nav.remainingDistance <= _range && control.CanSeePlayer())
            {
                _nav.SetDestination(control.transform.position);
                control.Attack();
            }
        }

        public override string ToString()
        {
            return "Spawning";
        }
    }
}
