using DaemonsGate.UI;
using System.Collections;
using System.Collections.Generic;
using Health;
using UnityEngine;
using UnityEngine.Events;

namespace DaemonsGate.Health
{
    public class EnemyHealthControl : BaseHealthControl
    {
        [SerializeField] float maxHitPoints;
        protected Health health;
        [SerializeField]
        float currentHitPoints;
        protected UIHealthBar healthbar;


        // Start is called before the first frame update
        protected void Start()
        {
            if (maxHitPoints == 0)
            {
                Debug.LogWarning($"You have not set a health value for this gameObject: {gameObject.name}");
            }
            health = new Health(maxHitPoints);
            currentHitPoints = health.Hitpoints;
            healthbar = GetComponentInChildren<UIHealthBar>();
        }

        public override void TakeDamage(float value)
        {
            health?.Damage(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
        }

        public override void Heal(float value)
        {
            health?.Heal(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
        }

        public override void IncreaseMaxHealth(float value, bool increaseCurrentHealth)
        {
            health?.IncreaseMaxHitPoints(value, increaseCurrentHealth);
            currentHitPoints = health.Hitpoints;
        }

        public override bool IsDead()
        {
            if (health.IsDead())
            {
                healthbar.gameObject.SetActive(false);
            }
            return health.IsDead();
        }
    }
}
