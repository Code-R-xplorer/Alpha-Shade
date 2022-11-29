using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChasePlayer : ActionNode
{
    public float tolerance = 1.0f;
    protected override void OnStart() {
        context.agent.destination = blackboard.playerPosition;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.agent.destination = blackboard.playerPosition;
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            // blackboard.generateSearchPoints = true;
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Running;
    }
}
