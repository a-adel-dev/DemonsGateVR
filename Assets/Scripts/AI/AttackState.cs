using DaemonsGate.Interfaces;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class AttackState : BaseState
    {
        IEnemyAttack _attacker;
        IAnimationManager _animationManager;
        bool _attacking;
        GameObject _player;
        NavMeshAgent _agent;
        EnemeyBehaviorControl _control;

        public override void EnterState(
            EnemeyBehaviorControl control,
            NavMeshAgent nav,
            GameObject player,
            float range,
            IAnimationManager animationManager,
            IEnemyAttack _enemyAttack
        )
        {
            control.currentState = "Attacking";
            _attacker = _enemyAttack;
            _animationManager = animationManager;
            _player = player;
            _agent = nav;
            _control = control;

            //seek player
            Vector3 playerDirection = (
                player.transform.position - control.transform.position
            ).normalized;
            if (Vector3.Dot(playerDirection, control.transform.forward) > 0.9)
            {
                _animationManager.Attack();
                nav.destination = control.transform.position;
                _attacker.Attack();
            }
            else
            {
                LookAtPlayer();
            }
        }

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
        ) { }

        public override void Update(EnemeyBehaviorControl control)
        {
            LookAtPlayer();
        }

        private void LookAtPlayer()
        {
            if (_attacking)
                return;
            Vector3 playerDirection = (
                _player.transform.position - _control.transform.position
            ).normalized;
            if (Vector3.Dot(playerDirection, _control.transform.forward) > 0.99)
            {
                _agent.destination = _player.transform.position;
                _animationManager.Attack();
                _agent.destination = _control.transform.position;
                _attacker.Attack();
                _attacking = true;
            }
            else
            {
                _agent.destination = _control.transform.position;
                playerDirection.y = 0;
                Quaternion rotation = Quaternion.LookRotation(playerDirection);
                _control.transform.rotation = Quaternion.Slerp(
                    _control.transform.rotation,
                    rotation,
                    .01f
                );
            }
        }
    }
}
