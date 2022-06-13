using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DaemonsGate.Health
{
    public class HealthControl : MonoBehaviour
    {
        [SerializeField] float maxHitPoints;
        Health hitPoints;
        float hp;


        // Start is called before the first frame update
        void Start()
        {
            if (maxHitPoints == 0)
            {
                Debug.LogWarning($"You have not set a health value for this gameObject: {gameObject.name}");
            }
            hitPoints = new Health(maxHitPoints);
            hp = hitPoints.Hitpoints;
        }

        public void Damage(float value)
        {
            hitPoints?.Damage(value);
            hp = hitPoints.Hitpoints;
        }

        public void Heal(float value)
        {
            hitPoints?.Heal(value);
            hp = hitPoints.Hitpoints;
        }

        public void IncreaseMaxHealth(float value, bool increaseCurrentHealth)
        {
            hitPoints?.IncreaseMaxHitPoints(value, increaseCurrentHealth);
            hp = hitPoints.Hitpoints;
        }

        public bool IsDead()
        {
            return hitPoints.IsDead();
        }
    }
}
