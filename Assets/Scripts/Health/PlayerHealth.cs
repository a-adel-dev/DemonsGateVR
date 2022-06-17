using DaemonsGate.Health;
using DaemonsGate.UI;
using UnityEngine;
using UnityEngine.Events;
using Utilities.Events;

namespace Health
{
    public class PlayerHealth : BaseHealthControl
    {
        [SerializeField] float maxHitPoints;
        protected DaemonsGate.Health.Health health;
        [SerializeField]
        float currentHitPoints;
        protected UIHealthBar healthbar;
        private PlayerDeadEvent playerDead = new PlayerDeadEvent();
        private bool _isDead;


        // Start is called before the first frame update
        void Start()
        {
            EventManager.AddInvoker(this);
            if (maxHitPoints == 0)
            {
                Debug.LogWarning($"You have not set a health value for this gameObject: {gameObject.name}");
            }
            health = new DaemonsGate.Health.Health(maxHitPoints);
            currentHitPoints = health.Hitpoints;
            healthbar = GetComponentInChildren<UIHealthBar>();
        }

        public override void TakeDamage(float value)
        {
            health?.Damage(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
            _isDead = IsDead();
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
                playerDead.Invoke();
            }
            return health.IsDead();
        }

        public void AddPLayerDeadEventListener(UnityAction listener)
        {
            playerDead.AddListener(listener);
        }
    }
}