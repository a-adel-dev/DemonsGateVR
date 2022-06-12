using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Core
{
    public class Timer
    {
        public float Duration { get; set; }
        private float elapsedTime;
        bool _isOver = false;


        public Timer(float duration)
        {
            Duration = duration;
        }

        public void PassTime(float value)
        {
            elapsedTime += value;
            if (elapsedTime >= Duration)
            {
                _isOver = true;
            }
        }

        public bool isTimerUp()
        {
            return _isOver;
        }

        public float ElapsedTime()
        {
            return elapsedTime;
        }

        public void Reset()
        {
            elapsedTime = 0;
            _isOver = false;
        }
    }
}