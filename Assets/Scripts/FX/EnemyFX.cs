using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.FX
{
    public class EnemyFX : MonoBehaviour, IFXManager
    {
        public void PlayFX(IFX fx)
        {
            fx.PlayEffect();
        }
    }
}
