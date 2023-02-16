using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class CheckBool : ActionNode
{
    public Context.BlackboardValues blackboardValues = Context.BlackboardValues.Default;
    // public string name;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        switch (blackboardValues)
        {
            case Context.BlackboardValues.CanSeePlayer:
                return blackboard.canSeePlayer ? State.Success : State.Failure;
            case Context.BlackboardValues.IsChasing:
                return blackboard.isChasing ? State.Success : State.Failure;
            case Context.BlackboardValues.GenerateSearchPoints:
                return blackboard.generateSearchPoints ? State.Success : State.Failure;
            case Context.BlackboardValues.Investigate:
                return blackboard.investigate ? State.Success : State.Failure;
            case Context.BlackboardValues.Default:
                Debug.LogWarning("Bool can't be changed, no case provided");
                return State.Failure;
        }
        return State.Success;
    }

}
