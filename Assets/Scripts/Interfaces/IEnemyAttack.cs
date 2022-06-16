using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Interfaces
{
    public interface IEnemyAttack
    {
        void Attack(WeaponIK weaponIK);
        void StopAttack();
    }
}
