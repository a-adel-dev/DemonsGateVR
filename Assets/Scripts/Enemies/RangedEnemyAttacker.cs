using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonsGate.Weapons;

namespace DaemonsGate.Enemies
{
    public class RangedEnemyAttacker : MonoBehaviour, IEnemyAttack
    {
        [SerializeField]
        Weapon weapon;
        
        public void Attack()
        {
            if (weapon == null) { Debug.Log($"No weapon is found on game object : {gameObject.name}");}
            weapon.WeaponAttack();
        }

        public void StopAttack()
        {
            throw new System.NotImplementedException();
        }

    }
}
