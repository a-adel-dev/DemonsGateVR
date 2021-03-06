using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.Enemies
{
    public class RangedEnemy : BaseEnemy, IEnemy
    {
        [SerializeField]
        float shootingDistance;
        [SerializeField]
        bool visualizeRange;

        public GameObject GameObject => gameObject;

        public float ShootingDistance { get => shootingDistance; set => shootingDistance = value; }

        private void Start()
        {

        }

        private void OnDrawGizmosSelected()
        {
            if (visualizeRange)
            {
                Gizmos.DrawWireSphere(transform.position, ShootingDistance);
            }
        }

    }
}
