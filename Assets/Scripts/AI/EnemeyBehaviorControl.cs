using DaemonsGate.Interfaces;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class EnemeyBehaviorControl : MonoBehaviour
    {
        //exposed for debugging
        public string currentState;
        BaseState _currentState;
        NavMeshAgent nav;
        GameObject player;
        IEnemy enemy;
        IAnimationManager _animator;

        public GameObject Player
        {
            get => player;
            set => player = value;
        }
        public BaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }
        public IAnimationManager Animator { get => _animator; set => _animator = value; }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            nav = GetComponent<NavMeshAgent>();
            Animator = GetComponent<IAnimationManager>();
            enemy = GetComponent<IEnemy>();
            if (player is null)
            {
                return;
            }
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            CurrentState = new SpawnState();
            CurrentState.EnterState(this, nav, Player, enemy.ShootingDistance, Animator);
        }

        private void Update()
        {
            if (CurrentState is null)
                return;
            CurrentState.Update(this);
        }

        internal void Attack()
        {
            CurrentState = new AttackState();
            CurrentState.EnterState(this, nav, Player, enemy.ShootingDistance, Animator);
        }

        public void TransitionToState(BaseState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this, nav, Player, enemy.ShootingDistance, Animator);
        }

        public void SeekPlayer(float range)
        {
            CurrentState = new SeekingState();
            CurrentState.EnterState(this, nav, Player, enemy.ShootingDistance, Animator);
        }

        public bool CanSeePlayer()
        {
            bool seePlayer = true;

            Vector3 distance = player.transform.position - transform.position;
            RaycastHit hit;
            Debug.DrawRay(this.transform.position, distance, Color.red);

            if (Physics.Raycast(transform.position, distance, out hit))
            {
                if (hit.collider.gameObject.tag == "Obstacle")
                {
                    seePlayer = false;
                }
            }
            return seePlayer;
        }
    }
}
