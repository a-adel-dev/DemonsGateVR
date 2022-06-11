using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Enemies
{
    public class RangedEnemyAttacker : MonoBehaviour, IEnemyAttack
    {
        public void Attack()
        {
            Debug.Log("Shooting");
        }

        public void StopAttack()
        {
            throw new System.NotImplementedException();
        }

    }
}
