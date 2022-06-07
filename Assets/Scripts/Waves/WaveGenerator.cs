using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Waves
{
    public class WaveGenerator : MonoBehaviour
    {
        Wave[] waves;


        float _waveTime;

        private void Start()
        {
            if (waves.Length > 0)
            {
                _waveTime = waves[0].waveTime;
            }
        }


    }
}