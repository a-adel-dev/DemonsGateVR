using DaemonsGate.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaemonsGate.Enemies
{
    public class RagDoll : MonoBehaviour
    {
        Rigidbody[] rigidBodies;
        [SerializeField] float mass;
        IAnimationManager animationManager;
        void Awake()
        {
            rigidBodies = GetComponentsInChildren<Rigidbody>();
            animationManager = GetComponent<IAnimationManager>();
            foreach (var rigidBody in rigidBodies)
            {
                rigidBody.mass = mass;
            }
        }

        public void DeactivateRagDoll()
        {
            foreach (var rigidBody in rigidBodies)
            {
                rigidBody.isKinematic = true;
            }
            animationManager.EnableAnimator();
        }

        public void ActivateRagDoll()
        {
            foreach (var rigidBody in rigidBodies)
            {
                rigidBody.isKinematic = false;
            }
            animationManager.DisableAnimator();
        }
    }
}
