using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Health
{
    public class HitBox : MonoBehaviour
    {
        EnemyHealthControl _enemyHealthControl;

        public void TakeDamage(float value)
        {
            _enemyHealthControl.TakeDamage(value);
        }
    }
}
