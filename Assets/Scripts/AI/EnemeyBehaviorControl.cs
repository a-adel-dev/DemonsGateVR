using DaemonsGate.Health;
using DaemonsGate.Enemies;
using DaemonsGate.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using HurricaneVR.Framework.Components;

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
        IEnemyAttack _enemyAttack;
        HealthControl _health;
        RagDoll ragdoll;
        IFXManager fxmanager;

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
        public IAnimationManager Animator
        {
            get => _animator;
            set => _animator = value;
        }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            nav = GetComponent<NavMeshAgent>();
            AssertComponent<NavMeshAgent>(nav);
            Animator = GetComponent<IAnimationManager>();
            AssertComponent<IAnimationManager>(Animator);
            _enemyAttack = GetComponent<IEnemyAttack>();
            AssertComponent<IEnemyAttack>(_enemyAttack);
            enemy = GetComponent<IEnemy>();
            _health = GetComponent<HealthControl>();
            ragdoll = GetComponent<RagDoll>();
            fxmanager = GetComponent<IFXManager>();
            if (player is null)
            {
                return;
            }
            SpawnEnemy();
        }

        private void AssertComponent<T>(object comp)
        {
            if (comp is null)
            {
                Debug.LogError($" no {typeof(T)} component on gameObject :{gameObject.name}");
            }
        }

        private void SpawnEnemy()
        {
            CurrentState = new SpawnState();
            CurrentState.EnterState(
                this,
                nav,
                Player,
                enemy.ShootingDistance,
                Animator,
                _enemyAttack
            );
            ragdoll.DeactivateRagDoll();
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
            CurrentState.EnterState(
                this,
                nav,
                Player,
                enemy.ShootingDistance,
                Animator,
                _enemyAttack
            );
        }

        public void TransitionToState(BaseState state)
        {
            CurrentState = state;
            CurrentState.EnterState(
                this,
                nav,
                Player,
                enemy.ShootingDistance,
                Animator,
                _enemyAttack
            );
        }

        public void SeekPlayer(float range)
        {
            CurrentState = new SeekingState();
            CurrentState.EnterState(
                this,
                nav,
                Player,
                enemy.ShootingDistance,
                Animator,
                _enemyAttack
            );
        }

        public void SeekPlayer()
        {
            CurrentState = new SeekingState();
            CurrentState.EnterState(
                this,
                nav,
                Player,
                enemy.ShootingDistance,
                Animator,
                _enemyAttack
            );
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

        public void TakeDamage(float damage)
        {
            /*           BaseState previousState = CurrentState;
                           CurrentState = new DamagedState();
                           CurrentState.EnterState(
                               this,
                               Animator,
                               previousState
                           );*/
            fxmanager.FXTakeDamage();
        }

        public void Die(Vector3 direction, float force, Vector3 hitpoint, DGDamageHandler damgeHandler)
        {
/*            CurrentState = new DeadState();
            CurrentState.EnterState(
                    this,
                    nav,
                    Player,
                    enemy.ShootingDistance,
                    Animator,
                    _enemyAttack
                );*/
            ragdoll.ActivateRagDoll();
            //Insert Death FX here
            damgeHandler.GetComponent<Rigidbody>().AddForceAtPosition(direction.normalized * force, hitpoint, ForceMode.VelocityChange);
        }
    }
}
