using System;
using DaemonsGate.Interfaces;
using DaemonsGate.Core;
using DaemonsGate.UI;
using TMPro;
using UnityEngine;

namespace DaemonsGate.Waves
{
    public class WaveGenerator : MonoBehaviour
    {
        [SerializeField] Wave[] waves;

        [SerializeField] string debugText;

        [SerializeField] private float idleTime = 10f;


        IEnemySpawner _spawner;

        float _waveTime;
        Timer _wavetimer;
        private Timer _idleTimer;
        int _currentWave;
        bool _spawning = true;
        private WaveInfoUI _waveInfoUI;
        private GameState _gameState;
        private bool spawned;
        private bool _playerAlive = true;



        private void Awake()
        {
            _spawner = (IEnemySpawner) GetComponent<EnemySpawner>();
            _waveInfoUI = GetComponent<WaveInfoUI>();
            _idleTimer = new Timer(idleTime);
        }

        private void Start()
        {
            _gameState = GameState.Initializing;
            EventManager.AddListener(EventName.PlayerDeadEvent, GameOver);
        }

        private void Update()
        {
            if (_playerAlive == false)
            {
                _gameState = GameState.GameOver;
            }
            switch (_gameState)
            {
                case GameState.Initializing:
                    debugText = "init";
                    _idleTimer.PassTime(Time.deltaTime);
                    if (_idleTimer.isTimerUp())
                    {
                        _spawning = true;
                        _gameState = GameState.WaveInProgress;
                        _idleTimer.Reset();
                    }

                    break;
                case GameState.WaveInProgress:
                    debugText = "inProgress";
                    AdvanceWave();
                    _waveInfoUI.ShowTimer(true);
                    _waveInfoUI.UpdateWaveTimer(_waveTime - _wavetimer.ElapsedTime(), _currentWave);
                    _wavetimer.PassTime(Time.deltaTime);
                    if (_wavetimer.isTimerUp())
                    {
                        if (_currentWave == waves.Length)
                        {
                            _gameState = GameState.Win;
                            _spawning = false;
                        }
                        else
                        {
                            _gameState = GameState.WaveOver;
                        }
                    }
                    break;
                case GameState.WaveOver:
                    debugText = "waveOver";
                    _idleTimer.PassTime(Time.deltaTime);
                    _gameState = GameState.WaveOver;
                    _waveInfoUI.ShowTimer(false);
                    if (_idleTimer.isTimerUp())
                    {
                        _spawning = true;
                        _gameState = GameState.WaveInProgress;
                        _idleTimer.Reset();
                    }

                    break;
                case GameState.GameOver:
                    _waveInfoUI.ShowTimer(false);
                    _waveInfoUI.ShowGameOver(true);
                    debugText = "Over";
                    break;
                case GameState.Win:
                    debugText = "win";
                    _waveInfoUI.ShowTimer(false);
                    _waveInfoUI.ShowWinText(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AdvanceWave()
        {
            if (_spawning is false)
                return;
            

            _waveTime = waves[_currentWave].WaveDuration;
            _wavetimer = new Timer(_waveTime);
            _spawner.SpawnWave(waves[_currentWave]);
            _currentWave++;
            _spawning = false;
        }
        
        public void GameOver()
        {
            _playerAlive = false;
        }
    }


    enum GameState
    {
        Initializing,
        WaveInProgress,
        WaveOver,
        GameOver,
        Win
    }
}
