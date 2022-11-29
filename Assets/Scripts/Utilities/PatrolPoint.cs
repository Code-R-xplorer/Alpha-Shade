using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    [SerializeField] private Color gizmoColour = Color.blue;
    [SerializeField] private float gizmoRadius = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColour;
        Gizmos.DrawWireSphere(transform.position, gizmoRadius);
    }
}
