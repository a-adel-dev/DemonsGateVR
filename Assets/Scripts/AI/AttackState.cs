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
        EnemeyBehaviorControl _control;

        public override void EnterState(EnemeyBehaviorControl control, NavMeshAgent nav, GameObject player, float range,
            IAnimationManager animationManager, IEnemyAttack _enemyAttack)
        {
            control.currentState = "Attacking";
            _attacker = _enemyAttack;
            _animationManager = animationManager;
            _player = player;
            _control = control;
        }

        private void Attack()
        {
            if (_attacking)
            {
                if (_attacker.Reloading())
                {
                    _control.Reload();
                }
                else 
                {
                    _animationManager.Attack();
                    _attacker.Attack(_control.WeaponIk);
                }
            }
        }

        public override void Update(EnemeyBehaviorControl control)
        {
            SeekPlayer(control);
            Attack();
        }

        private void SeekPlayer(EnemeyBehaviorControl control)
        {
            if (_attacking)
            {
                return;
            }

            Vector3 playerDirection = (_player.transform.position - _control.transform.position).normalized;
            if (Vector3.Dot(playerDirection, _control.transform.forward) > 0.99)
            {
                _attacking = true;
            }
            else
            {
                playerDirection.y = 0;
                Quaternion rotation = Quaternion.LookRotation(playerDirection);
                _control.transform.rotation = Quaternion.Slerp(_control.transform.rotation, rotation, .01f);
            }
        }

        public override void EnterState(
            EnemeyBehaviorControl control,
            IAnimationManager animator,
            BaseState previousState
        ) { }
    }
}
