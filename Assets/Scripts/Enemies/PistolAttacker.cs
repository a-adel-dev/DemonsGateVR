using System;
using System.Collections;
using DaemonsGate.Interfaces;
using DaemonsGate.Weapons;
using UnityEngine;

namespace DaemonsGate.Enemies
{
    public class PistolAttacker : MonoBehaviour, IEnemyAttack
    {
        [SerializeField] private RayCastWeapon pistol;
        private bool _shooting = true;
        
        private void Start()
        {
            pistol.ReloadFinished();
            pistol.ResetShot();
        }
        
        public void Attack(WeaponIK weaponIK)
        {
            weaponIK.SetAimTransform(pistol.GetRayCastObject());
            Shoot();
        }

        void Shoot()
        {
            
            if (pistol.BulletsLeft <= 0 && !pistol.Reloading )
            {
                Reload();
            }
            if (_shooting == false) return;
            if (pistol.ReadyToShoot && !pistol.Shooting && !pistol.Reloading)
            {
                pistol.Shoot();
                _shooting = false;
            }

            Invoke(nameof(ResetShot), pistol.TimeBetweenShooting);
        }

        void ResetShot()
        {
            _shooting = true;
            pistol.ResetShot();
        }

        

        void Reload()
        {
            pistol.Reload();
            Invoke(nameof(FinishReloading), pistol.ReloadTime);
        }

        public void StopAttack()
        {
            throw new System.NotImplementedException();
        }

        public float GetTimeBetweenShooting()
        {
            return pistol.TimeBetweenShooting;
        }

        public bool CanAttack()
        {
            return pistol.ReadyToShoot && !pistol.Shooting && !pistol.Reloading;
        }

        public bool Reloading()
        {
            return pistol.Reloading;
        }

        private void FinishReloading()
        {
            pistol.ReloadFinished();
        }
    }
}