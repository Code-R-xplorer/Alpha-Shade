using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GoToSearchPoint : ActionNode
{
    public float tolerance = 1.0f;
    protected override void OnStart() {
        context.agent.destination = blackboard.searchPositions[blackboard.searchIndex];
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            blackboard.searchIndex++;
            if (blackboard.searchIndex > blackboard.patrolPoints.Count - 1) return State.Failure;
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        if (blackboard.canSeePlayer || blackboard.investigate)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
