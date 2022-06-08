using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Interfaces
{
    public interface IEnemySpawner
    {
        GameObject GameObject { get; }
        void SpawnWave(IWave wave);
    }
}
