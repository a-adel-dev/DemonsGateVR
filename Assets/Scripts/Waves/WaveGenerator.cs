using DaemonsGate.Interfaces;
using DaemonsGate.Core;
using TMPro;
using UnityEngine;

namespace DaemonsGate.Waves
{
    public class WaveGenerator : MonoBehaviour
    {
        [SerializeField]
        Wave[] waves;

        [SerializeField]
        bool debugMode;

        
        IEnemySpawner _spawner;

        float _waveTime;
        Timer _wavetimer;
        int _currentWave;
        bool _spawning = true;
        private bool _waveInProgress = false;

        private Timer _uiUpdate;
        private TextMeshPro waveTimer;

        private void Awake()
        {
            _spawner = (IEnemySpawner)GetComponent<EnemySpawner>();
            _uiUpdate = new Timer(1.0f);
        }

        private void Update()
        {
            if (_uiUpdate.isTimerUp() && _waveInProgress && waveTimer != null)
            {
                waveTimer.text = _wavetimer.ElapsedTime().ToString();
            }
            if (_wavetimer is null)
            {
                return;
            }
            if (_wavetimer != null)
            {
                _wavetimer.PassTime(Time.deltaTime);
            }
            if (_wavetimer.isTimerUp()) //TODO: Assert that enemies are dead and that player is alive
            {
                AdvanceWave();
            }
        }

        public void BeginWaves()
        {
            if (_spawner is null)
            {
                Debug.LogError($"No EnemySpawner component on game object: {gameObject.name}");
            }
            if (waves.Length > 0)
            {
                AdvanceWave();
            }
        }

        private void AdvanceWave()
        {
            _waveInProgress = true;
            if (_spawning is false)
                return;
            if (_currentWave == waves.Length)
            {
                _waveInProgress = false;
                //raise Win event
                if (debugMode)
                {
                    Debug.Log($"Waves are complete!");
                }
                _spawning = false;
                return;
            }
            _waveTime = waves[_currentWave].WaveDuration;
            _wavetimer = new Timer(_waveTime);
            SpawnWave(waves[_currentWave]);
            if (debugMode)
            {
                Debug.Log($"Spawning wave: {waves[_currentWave].WaveId}");
            }
            _currentWave++;
        }

        void SpawnWave(Wave wave)
        {
            if (waves.Length <= 0)
            {
                Debug.LogError(
                    $"Wave spawn Faild. There are no Waves in the list. Make sure "
                        + $"to add at least 1 wave."
                );
                return;
            }

            _spawner.SpawnWave(wave);
        }
    }
}
