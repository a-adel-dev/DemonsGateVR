using System;
using DaemonsGate.Health;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DaemonsGate.Weapons
{
    public class RayCastWeapon : Weapon
    {
        [SerializeField]
        int damage;

        [SerializeField] private float _timeBetweenShooting;
        [SerializeField] private float _spread;
        [SerializeField] private float _range;
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _magazineSize;
        private AudioManager SFX;

        private int _bulletsLeft;
        public bool Shooting { get; }
        private bool _readyToShoot;
        
        public float ReloadTime
        {
            get => _reloadTime;
        }
        public float TimeBetweenShooting
        {
            get => _timeBetweenShooting;
        }
        
        public bool ReadyToShoot
        {
            get => _readyToShoot;
        }

        public int BulletsLeft
        {
            get => _bulletsLeft;
            set
            {
                _bulletsLeft = value;
            }
        }
        
        
        public bool Reloading { get; private set; }
        public RaycastHit rayHit;
        public LayerMask whatIsPlayer;
        [SerializeField]
        Transform _rayCastObject;

        public GameObject muzzleFlashPrefab, bulletholeGraphic;

        private void Start()
        {
            SFX = GetComponent<AudioManager>();
        }

        public override Transform GetRayCastObject()
        {
            return _rayCastObject;
        }
        
        public void Reload()
        {
            Reloading = true;
            BulletsLeft = _magazineSize;
            
        }

        public void ReloadFinished()
        {
            BulletsLeft = _magazineSize;
            Reloading = false;
        }

        public void Shoot()
        {
            _readyToShoot = false;
            
            //Spread
            float xSpread = Random.Range(-_spread, _spread);
            float ySpread = Random.Range(-_spread, _spread);
            
            //Calculate Direction with Spread
            Vector3 direction = _rayCastObject.forward + new Vector3(xSpread, ySpread, 0);
            Debug.DrawRay(_rayCastObject.position, direction, Color.magenta, 1f);
            SFX?.PlayPistolShotFX();
            //RayCast
            if (Physics.Raycast(_rayCastObject.position, direction * 10f, out rayHit, _range, whatIsPlayer))
            {
                //Debug.Log(rayHit.collider.name);
                
                if (rayHit.collider.CompareTag("Player"))
                {
                    rayHit.collider.GetComponent<HealthControl>().TakeDamage(damage);
                }
            }
            
            //Graphics
            if (bulletholeGraphic != null)
            {
                GameObject bulletHole = Instantiate(bulletholeGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
                Destroy(bulletHole, 3f);
            }

            if (muzzleFlashPrefab != null)
            {
                GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, _rayCastObject.position, Quaternion.identity);
                Destroy(muzzleFlash, 3f);
            }

            BulletsLeft --;
        }

        public void ResetShot()
        {
            _readyToShoot = true;
        }
    }
}