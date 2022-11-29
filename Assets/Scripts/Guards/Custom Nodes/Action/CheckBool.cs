using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class CheckBool : ActionNode
{
    public Context.BlackboardValues blackboardValues;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        switch (blackboardValues)
        {
            case Context.BlackboardValues.CanSeePlayer:
                if (blackboard.canSeePlayer) return State.Success;
                return State.Failure;
            case Context.BlackboardValues.IsChasing:
                if (blackboard.isChasing) return State.Success;
                return State.Failure;
            case Context.BlackboardValues.GenerateSearchPoints:
                if (blackboard.generateSearchPoints) return State.Success;
                return State.Failure;
            case Context.BlackboardValues.Default:
                Debug.LogWarning("Bool can't be changed, no case provided");
                return State.Failure;
        }
        return State.Success;
    }
}
