using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugNavMeshAgent : MonoBehaviour
{
    public bool velocity;
    public bool desiredVelocity;
    public bool path;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        if (velocity)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + agent.velocity);
        }

        if (desiredVelocity)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
        }

        if (path)
        {
            Gizmos.color = Color.blue;
            var agentPath = agent.path;
            Vector3 previousCorner = transform.position;
            foreach (var corner in agentPath.corners)
            {
                Gizmos.DrawLine(previousCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                previousCorner = corner;
            }
        }
    }
}
