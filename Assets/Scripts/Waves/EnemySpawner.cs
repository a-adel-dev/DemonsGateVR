using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonsGate.Interfaces;

namespace DaemonsGate.Waves
{
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        public GameObject GameObject => gameObject;
        [SerializeField] private GameObject spawnFXPrefab;
        
        public void SpawnWave(IWave wave)
        {
            if (wave.SpawnPositions.Length <= 0)
            {
                Debug.LogError(
                    $"Wave {wave.WaveId} spawn Faild. There are no spawn "
                        + $"positions in the list. Make sure to add at least 1 position."
                );
                return;
            }

            SpawnEnemy(wave);
        }

        public void SpawnEnemy(IWave wave)
        {
            int counter = 0;

            foreach (IEnemy enemy in wave.Enemies)
            {
                Instantiate(spawnFXPrefab, wave.SpawnPositions[counter], Quaternion.identity);
                Instantiate(enemy.GameObject, wave.SpawnPositions[counter], Quaternion.identity);
                counter++;
                if (counter == wave.SpawnPositions.Length)
                {
                    counter = 0;
                }
            }
        }
    }
}
