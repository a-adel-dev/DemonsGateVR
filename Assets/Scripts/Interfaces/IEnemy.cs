using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Interfaces
{
    public interface IEnemy
    {
        GameObject GameObject { get; }
        float ShootingDistance { get; set; }
    }
}
