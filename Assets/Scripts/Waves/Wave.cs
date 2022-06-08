using DaemonsGate.Interfaces;
using UnityEngine;

namespace DaemonsGate.Waves
{

    [CreateAssetMenu(fileName ="Wave", menuName = "DaemonsGate/Wave")]
    public class Wave : ScriptableObject
    {
        public int waveId = 0;
        public Vector3[] spawnPositions;
        public BaseEnemy[] enemies;
        public float waveDuration = 60f;
    }
}
