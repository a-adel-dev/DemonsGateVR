using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.FX
{
    public class BasicEnemyDeath : MonoBehaviour, IFX
    {
        public void PlayEffect()
        {
            Destroy(gameObject, 5f);
        }
    }
}
