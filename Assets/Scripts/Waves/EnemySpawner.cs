using System.Collections;
using System.Collections.Generic;
using DaemonsGate.FX;
using UnityEngine;
using DaemonsGate.Interfaces;
using UnityEngine.UIElements;

namespace DaemonsGate.Waves
{
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        public GameObject GameObject => gameObject;
        public float EnemySpawnTime = 2f;

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

            SpawnEnemies(wave);
        }

        public void SpawnEnemies(IWave wave)
        {

            int spawnPositionCounter = 0;

            foreach (IEnemy enemy in wave.Enemies)
            {
                enemy.GameObject.GetComponent<EnemyFX>().FXSpawn(wave.SpawnPositions[spawnPositionCounter]);

                StartCoroutine(SpawnEnemy(enemy.GameObject, wave, spawnPositionCounter));
                spawnPositionCounter++;
                if (spawnPositionCounter == wave.SpawnPositions.Length)
                {
                    spawnPositionCounter = 0;
                }
            }
        }

        IEnumerator SpawnEnemy(GameObject enemy, IWave wave, int index)
        {
            yield return new WaitForSeconds(Random.Range(0, EnemySpawnTime));
            Instantiate(enemy, wave.SpawnPositions[index], Quaternion.identity);
        }
    }
}
