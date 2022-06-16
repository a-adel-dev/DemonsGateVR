using DaemonsGate.AI;
using DaemonsGate.Health;
using HurricaneVR.Framework.Weapons;
using UnityEngine;

namespace HurricaneVR.Framework.Components
{
    public class DGDamageHandler : HVRDamageHandlerBase
    {
        //public float Life = 100f;
        HealthControl healthControl;
        EnemeyBehaviorControl behaviorControl;

        public bool Damageable = true;

        public Rigidbody Rigidbody { get; private set; }

        void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            healthControl = transform.root.GetComponent<HealthControl>();
            behaviorControl = transform.root.GetComponent<EnemeyBehaviorControl>();
        }

        public override void TakeDamage(float damage)
        {
            if (Damageable)
            {
                healthControl.TakeDamage(damage);
                if (healthControl.IsDead() == false)
                {
                    behaviorControl.TakeDamage(damage);
                }
                
            }
        }

        public override void HandleDamageProvider(HVRDamageProvider damageProvider, Vector3 hitPoint, Vector3 direction)
        {
            base.HandleDamageProvider(damageProvider, hitPoint, direction);

            if (Rigidbody && healthControl.IsDead())
            {
                behaviorControl.Die(direction.normalized, damageProvider.Force, hitPoint, this);
            }
        }

    }
}