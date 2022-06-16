using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Health
{
    public class HitBox : MonoBehaviour
    {
        HealthControl healthControl;

        public void TakeDamage(float value)
        {
            healthControl.TakeDamage(value);
        }
    }
}
