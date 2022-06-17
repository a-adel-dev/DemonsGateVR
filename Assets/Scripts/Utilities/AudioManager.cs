using System;
using System.Collections;
using System.Collections.Generic;
using DaemonsGate.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SFXSO gunSFX;

    public void PlayPistolShotFX()
    {
        gunSFX?.Play(gameObject);
    }
}
