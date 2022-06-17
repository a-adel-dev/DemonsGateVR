using System;
using DaemonsGate.Core;
using TMPro;
using UnityEngine;

namespace DaemonsGate.UI
{
    public class WaveInfoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private TextMeshProUGUI GameOverText;
        private Timer _updateTimer;
        private float time;
        private bool canUpdate;
        


        public string FormatTime( float time )
        {
            int minutes = (int) time / 60 ;
            int seconds = (int) time - 60 * minutes;
            int milliseconds = (int) (1000 * (time - minutes * 60 - seconds));
            return string.Format("{0:00}:{1:00}", minutes, seconds );
        }
        void Start()
        {
            _updateTimer = new Timer(1.0f);
            ShowTimer(false);
        }

        private void Update()
        {
            _updateTimer.PassTime(Time.deltaTime);
            if (_updateTimer.isTimerUp())
            {
                canUpdate = true;
                _updateTimer.Reset();
            }
        }

        public void UpdateWaveTimer(float waveTime, int waveCount)
        {
            if (canUpdate)
            {
                timeText.text = $"Wave:{waveCount} - {FormatTime(waveTime)}";
                canUpdate = false;
            }
            
        }

        public void ShowTimer(bool show)
        {
            timeText.enabled = show;
        }

        public void ShowGameOver(bool show)
        {
            GameOverText.enabled = show;
        }

        public void ShowWinText(bool show)
        {
            winText.enabled = show;
        }
    }
}