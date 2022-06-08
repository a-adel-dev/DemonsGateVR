using DaemonsGate.Interfaces;
using DaemonsGate.Core;
using UnityEngine;

namespace DaemonsGate.Waves
{
    public class WaveGenerator : MonoBehaviour
    {
        [SerializeField] Wave[] waves;
        Vector3[] _spawnPositions;
        

        float _waveTime;
        Timer _timer;
        int _waveCounter;

        private void Start()
        {
            if (waves.Length > 0)
            {
                AdvanceWave();
            }
        }

        private void AdvanceWave()
        {
            _spawnPositions = waves[_waveCounter].spawnPositions;
            _waveTime = waves[_waveCounter].waveDuration;
            _timer = new Timer(_waveTime);
            SpawnWave(_waveCounter);
            _waveCounter++;
            if (_waveCounter == waves.Length - 1)
            {
                //raise Win event
            }
        }

        private void Update()
        {
            if (_timer is null) { return; }
            if (_timer != null)
            {
                _timer.PassTime(Time.deltaTime);
            }
            if (_timer.isTimerUp()) //TODO: Assert that enemies are dead and that player is alive
            {
                AdvanceWave();
            }
        }

        void SpawnWave(int waveId)
        {
            if (_spawnPositions.Length <= 0)
            {
                Debug.LogError($"Wave {waves[_waveCounter].waveId} spawn Faild. There are no spawn positions in the list. Make sure to add at least 1 position.");
                return;
            }

            if (waves.Length <= 0)
            {
                Debug.LogError($"Wave spawn Faild. There are no Waves in the list. Make sure to add at least 1 wave.");
                return;
            }

            int counter = 0;

            foreach (IEnemy enemy in waves[waveId].enemies)
            {
                Instantiate(enemy.GameObject, _spawnPositions[counter], Quaternion.identity);
                counter++;
                if (counter == _spawnPositions.Length)
                {
                    counter = 0;
                }
            }
        }


    }
}