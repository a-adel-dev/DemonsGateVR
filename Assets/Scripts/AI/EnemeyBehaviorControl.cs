using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class EnemeyBehaviorControl : MonoBehaviour
    {
        BaseState _currentState;
        NavMeshAgent nav;
        GameObject player;
        float _range;

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

        private void Start()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (CurrentState is null)
                return;
            CurrentState.Update(this, nav, Player);
        }

        internal void Attack()
        {
            CurrentState = new AttackState();
            CurrentState.EnterState(this, nav, Player, _range);
        }

        public void TransitionToState(BaseState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this, nav, Player, _range);
        }

        public void SeekPlayer(float range)
        {
            _range = range;
            CurrentState = new SeekingState();
            CurrentState.EnterState(this, nav, Player, _range);
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
