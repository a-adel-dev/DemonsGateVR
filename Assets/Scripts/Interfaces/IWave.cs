using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Interfaces
{
    public interface IWave
    {
        Vector3[] SpawnPositions { get; }
        float WaveDuration { get; }
        int WaveId { get; }
        BaseEnemy[] Enemies { get; }
    }
}