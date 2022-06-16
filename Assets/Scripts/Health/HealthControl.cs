using DaemonsGate.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaemonsGate.Health
{
    public class HealthControl : MonoBehaviour
    {
        [SerializeField] float maxHitPoints;
        Health health;
        [SerializeField]
        float currentHitPoints;
        UIHealthBar healthbar;


        // Start is called before the first frame update
        void Start()
        {
            if (maxHitPoints == 0)
            {
                Debug.LogWarning($"You have not set a health value for this gameObject: {gameObject.name}");
            }
            health = new Health(maxHitPoints);
            currentHitPoints = health.Hitpoints;
            healthbar = GetComponentInChildren<UIHealthBar>();
        }

        public void TakeDamage(float value)
        {
            health?.Damage(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
        }

        public void Heal(float value)
        {
            health?.Heal(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
        }

        public void IncreaseMaxHealth(float value, bool increaseCurrentHealth)
        {
            health?.IncreaseMaxHitPoints(value, increaseCurrentHealth);
            currentHitPoints = health.Hitpoints;
        }

        public bool IsDead()
        {
            if (health.IsDead())
            {
                healthbar.gameObject.SetActive(false);
            }
            return health.IsDead();
        }
    }
}
