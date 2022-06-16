using DaemonsGate.Core;
using UnityEngine;

namespace DaemonsGate.Weapons
{
    public class AutoRifle : Weapon
    {
        [SerializeField]
        int damage;

        [SerializeField]
        float timeBetweenShooting,
            spread,
            range,
            bulletSpeed;

        [SerializeField]
        Transform shootingPoint;

        [SerializeField]
        GameObject bulletPrefab;

        bool _shooting,
            reloading;
        Timer shootingCoolDown;

        [SerializeField]
        LayerMask playerLayer;

        [SerializeField]
        Transform rayCastObject;

        public new Transform RayCastObject { get => rayCastObject; set => rayCastObject = value; }

        private void Update()
        {
            Shoot();
        }

        public override void WeaponAttack()
        {
            _shooting = true;

        }

        void Shoot()
        {
            if (shootingCoolDown is not null)
            {
                shootingCoolDown.PassTime(Time.deltaTime);
                if (shootingCoolDown.isTimerUp())
                {
                    _shooting = true;
                }
            }
            if (_shooting == false)
            {
                return;
            }
            GameObject bullet = Instantiate(
                    bulletPrefab,
                    shootingPoint.transform.position,
                    shootingPoint.rotation
                );
            Vector3 bulletspread = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), 0f);
            bullet
                .GetComponent<Rigidbody>()
                .AddForce((transform.forward + bulletspread) * bulletSpeed, ForceMode.Impulse);

            if (shootingCoolDown is null)
            {
                shootingCoolDown = new Timer(timeBetweenShooting);
            }
            else
            {
                shootingCoolDown.Reset();
            }
            _shooting = false;
        }
    }
}
