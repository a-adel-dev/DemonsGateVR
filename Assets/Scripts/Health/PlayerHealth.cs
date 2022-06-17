using DaemonsGate.Health;
using DaemonsGate.UI;
using UnityEngine;
using UnityEngine.Events;
using Utilities.Events;
using UnityEngine.Rendering.PostProcessing;



namespace Health
{
    public class PlayerHealth : BaseHealthControl
    {
        [SerializeField] float maxHitPoints;
        protected DaemonsGate.Health.Health health;
        [SerializeField]
        float currentHitPoints;
        [SerializeField] protected UIHealthBar healthbar;
        private bool _isDead;
        private PostProcessProfile postProcessingProfile;


        // Start is called before the first frame update
        void Start()
        {
            
            unityEvents.Add(EventName.PlayerDeadEvent, new PlayerDeadEvent());
            EventManager.AddInvoker( EventName.PlayerDeadEvent, this);
            
            
            if (maxHitPoints == 0)
            {
                Debug.LogWarning($"You have not set a health value for this gameObject: {gameObject.name}");
            }
            health = new DaemonsGate.Health.Health(maxHitPoints);
            currentHitPoints = health.Hitpoints;

            postProcessingProfile = FindObjectOfType<PostProcessVolume>().profile;
        }

        public override void TakeDamage(float value)
        {
            health?.Damage(value);
            currentHitPoints = health.Hitpoints;
            healthbar.SetHealthBarPercentage(currentHitPoints / maxHitPoints);
            _isDead = IsDead();
            Vignette vignette;
            if (postProcessingProfile.TryGetSettings(out vignette))
            {
                float percent = 1.0f - currentHitPoints / health.MaxHitPoints;
                vignette.intensity.value = percent * 0.5f;
            }
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
                unityEvents[EventName.PlayerDeadEvent].Invoke();
            }
            return health.IsDead();
        }
        
    }
}