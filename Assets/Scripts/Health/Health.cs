using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Health
{
    public class Health
    {
        public float MaxHitPoints { get; set; }
        public float Hitpoints { get => _hitpoints; set => _hitpoints = value; }

        float _hitpoints;
        bool isDead = false;

        public Health(float health)
        {
            MaxHitPoints = health;
            Hitpoints = MaxHitPoints;
        }

        public void Damage(float value)
        {
            Hitpoints -= value;
            if (Hitpoints <= 0)
            {
                Hitpoints = 0;
                isDead = true;
            }
        }

        public void Heal(float value)
        {
            Hitpoints += value;
            if (Hitpoints > MaxHitPoints)
            {
                Hitpoints = MaxHitPoints;
            }
        }

        public bool IsDead()
        {
            return isDead;
        }

        public void IncreaseMaxHitPoints(float value, bool increaseCurrentHealth)
        {
            MaxHitPoints += value;
            if (increaseCurrentHealth)
            {
                Hitpoints = MaxHitPoints;
            }
        }
    }
}
