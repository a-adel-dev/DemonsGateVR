using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.FX
{
    public class EnemyFX : MonoBehaviour, IFXManager
    {
        [SerializeField]
        HitFX takeDamage;
        public void FXTakeDamage()
        {
            takeDamage.PlayEffect();
        }

        public void PlayFX(IFX fx)
        {
            fx.PlayEffect();
        }


    }
}
