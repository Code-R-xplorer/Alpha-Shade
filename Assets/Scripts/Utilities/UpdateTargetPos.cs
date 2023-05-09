using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTargetPos : MonoBehaviour
{
    [SerializeField] private Transform targetRef;

    private void Update()
    {
        transform.position = targetRef.position;
        transform.rotation = targetRef.rotation;
    }
}
