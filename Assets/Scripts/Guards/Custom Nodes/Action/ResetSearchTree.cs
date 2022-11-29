using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ResetSearchTree : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        blackboard.searchPositions = new List<Vector3>();
        blackboard.searchIndex = 0;
        return State.Success;
    }
}
