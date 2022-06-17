using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaemonsGate.Interfaces;
using DaemonsGate.Weapons;

namespace DaemonsGate.Enemies
{
    public class RayCastAttacker : MonoBehaviour, IEnemyAttack
    {
        [SerializeField]
        Weapon weapon;
        public void Attack(WeaponIK weaponIK)
        {
            if (weapon == null) { Debug.Log($"No weapon is found on game object : {gameObject.name}"); }
            weaponIK.SetAimTransform(weapon.GetRayCastObject());
        }

        public void StopAttack()
        {
            
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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
