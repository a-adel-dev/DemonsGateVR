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
        
        public void Attack(WeaponIK weaponIK)
        {
            if (weapon == null) { Debug.Log($"No weapon is found on game object : {gameObject.name}");}
            weaponIK.SetAimTransform(weapon.GetRayCastObject());
            //weapon.Attack();
        }

        public void StopAttack()
        {
            throw new System.NotImplementedException();
        }

        public float GetTimeBetweenShooting()
        {
            throw new System.NotImplementedException();
        }

        public bool CanAttack()
        {
            throw new System.NotImplementedException();
        }

        public bool Reloading()
        {
            throw new System.NotImplementedException();
        }
    }
}
