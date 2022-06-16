using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DaemonsGate.AI
{
    public class AILocomotion : MonoBehaviour
    {
        NavMeshAgent agent;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
