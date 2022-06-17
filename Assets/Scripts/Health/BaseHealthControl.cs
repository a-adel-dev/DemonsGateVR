using UnityEngine;

namespace Health
{
    public abstract class BaseHealthControl : EventInvoker
    {
        public abstract void TakeDamage(float value);

        public abstract void Heal(float value);


        public abstract void IncreaseMaxHealth(float value, bool increaseCurrentHealth);

        public abstract bool IsDead();

    }
}