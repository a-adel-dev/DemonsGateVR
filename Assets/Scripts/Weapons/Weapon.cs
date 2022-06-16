using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DaemonsGate.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public Transform RayCastObject { get; internal set; }

        public abstract void WeaponAttack();
    }
}
