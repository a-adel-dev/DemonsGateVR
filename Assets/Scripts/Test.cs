using DaemonsGate.Core;
using DaemonsGate.Waves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    float timerValue;

    [SerializeField]
    WaveGenerator generator;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        generator.BeginWaves();
    }

    // Update is called once per frame
    void Update()
    {


    }
}
