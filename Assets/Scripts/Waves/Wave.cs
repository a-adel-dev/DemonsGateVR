using DaemonsGate.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Waves
{

    [CreateAssetMenu(fileName = "Wave", menuName = "DaemonsGate/Wave")]
    public class Wave : ScriptableObject, IWave
    {
        public int waveId = 0;
        public Vector3[] spawnPositions;
        public BaseEnemy[] enemies;
        public float waveDuration = 60f;

        public Vector3[] SpawnPositions { get => spawnPositions; }

        public float WaveDuration => waveDuration;

        public int WaveId { get => waveId; }

        public BaseEnemy[] Enemies { get => enemies; }
    }
}
