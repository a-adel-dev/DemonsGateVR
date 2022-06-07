using DaemonsGate.Interfaces;
using UnityEngine;

namespace DaemonsGate.Waves
{

    [CreateAssetMenu(fileName ="Wave", menuName = "ScriptableObjects/")]
    public class Wave : ScriptableObject
    {
        public int waveId = 0;

        public IEnemy[] enemies;
        public float waveTime = 60f;
    }
}
