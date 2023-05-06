using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class GuardPosition : ActionNode
{
    public float tolerance = 1f;
    protected override void OnStart() {
        if (context.transform.position != blackboard.homePosition)
        {
            context.agent.destination = blackboard.homePosition;
        }
        else
        {
            context.agent.isStopped = true;
            context.agent.ResetPath();
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (context.transform.position == blackboard.homePosition) return State.Success;
        
        if (context.agent.pathPending) {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            context.transform.position = blackboard.homePosition;
            context.transform.rotation = blackboard.homeRotation;
            context.animation.ChangeState(Guards.Animation.AnimationState.Idle);
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid) {
            return State.Failure;
        }

        if (blackboard.canSeePlayer || blackboard.investigate)
        {
            return State.Failure;
        }
        context.animation.ChangeState(Guards.Animation.AnimationState.Patrolling);
        return State.Running;
    }
}