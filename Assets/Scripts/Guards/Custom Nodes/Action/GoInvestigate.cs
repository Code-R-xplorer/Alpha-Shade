using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GoInvestigate : ActionNode
{
    public float tolerance = 1.0f;
    
    protected override void OnStart() {
        context.agent.destination = blackboard.investigatePosition;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        if (blackboard.canSeePlayer)
        {
            blackboard.investigate = false;
            return State.Failure;
        }
        context.animation.ChangeState(Guards.Animation.AnimationState.Patrolling);
        return State.Running;
    }
}
