using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    [SerializeField] private bool enable = true;
    private void OnDrawGizmos()
    {
        if (enable)
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * 50);
        }
    }
}
