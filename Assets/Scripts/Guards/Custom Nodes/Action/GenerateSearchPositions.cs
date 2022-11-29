using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using Utilities;

[System.Serializable]
public class GenerateSearchPositions : ActionNode
{
    public int searchPoints;
    public int searchRadius;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        blackboard.searchPositions = Utils.GenerateSearchPoints(context.transform.position, searchPoints, searchRadius);
        return State.Success;
    }
}
