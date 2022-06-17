using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.FX
{
    public class EnemyFX : MonoBehaviour, IFXManager
    {
        [SerializeField]
        HitFX takeDamage;

        [SerializeField] private GameObject spawnFX;
        public void FXTakeDamage()
        {
            takeDamage.PlayEffect();
        }

        public void PlayFX(IFX fx)
        {
            fx.PlayEffect();
        }

        public void FXSpawn(Vector3 position)
        {
            if (spawnFX == null)
            {
                return;
            }

            Instantiate(spawnFX, position, Quaternion.identity);
        }

    }
}
