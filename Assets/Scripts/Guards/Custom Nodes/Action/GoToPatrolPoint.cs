using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GoToPatrolPoint : ActionNode
{
    public float tolerance = 1.0f;
    protected override void OnStart()
    {
        context.agent.destination = blackboard.patrolPoints[blackboard.patrolIndex].position;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.agent.remainingDistance < tolerance)
        {
            blackboard.patrolIndex++;
            if (blackboard.patrolIndex > blackboard.patrolPoints.Count - 1) blackboard.patrolIndex = 0;
            context.agent.destination = blackboard.patrolPoints[blackboard.patrolIndex].position;
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        return State.Success;
    }
}
