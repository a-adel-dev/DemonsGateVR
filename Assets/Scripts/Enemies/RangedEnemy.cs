using UnityEngine;
using DaemonsGate.AI;
using UnityEngine.AI;
using DaemonsGate.Interfaces;

namespace DaemonsGate.Enemies
{
    public class RangedEnemy : MonoBehaviour , IEnemy
    {
        [SerializeField]
        float range;
        GameObject player;
        EnemeyBehaviorControl brain;

        public GameObject GameObject => gameObject;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player is null) 
            {
                return;
            }
            brain = GetComponent<EnemeyBehaviorControl>();
            brain.Player = player;
            brain.SeekPlayer(range);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }

    }
}
