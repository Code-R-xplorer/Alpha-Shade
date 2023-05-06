using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChasePlayer : ActionNode
{
    public float tolerance = 1.0f;
    public float minDistanceSqr = 10f;
    protected override void OnStart() {
        context.agent.destination = blackboard.playerPosition;
        context.animation.ChangeState(Guards.Animation.AnimationState.Chasing);
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

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid || blackboard.stunned) {
            return State.Failure;
        }

        if (!blackboard.canSeePlayer) return State.Running;
        var destPosition = blackboard.playerPosition;
        var sqrDistance = (context.transform.position - destPosition).sqrMagnitude;

        context.agent.destination = destPosition;
        blackboard.playerInRange = sqrDistance <= minDistanceSqr;
        context.agent.isStopped = blackboard.playerInRange;
        if (!blackboard.playerInRange)
        {
            context.animation.ChangeState(Guards.Animation.AnimationState.Chasing);
        }

        return State.Running;
    }
}
