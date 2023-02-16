using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChangeBool : ActionNode
{
    public bool newValue;
    public Context.BlackboardValues blackboardValues = Context.BlackboardValues.Default;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        switch (blackboardValues)
        {
            case Context.BlackboardValues.CanSeePlayer:
                blackboard.canSeePlayer = newValue;
                break;
            case Context.BlackboardValues.IsChasing:
                blackboard.isChasing = newValue;
                break;
            case Context.BlackboardValues.GenerateSearchPoints:
                blackboard.generateSearchPoints = newValue;
                break;
            case Context.BlackboardValues.Investigate:
                blackboard.investigate = newValue;
                break;
            case Context.BlackboardValues.Default:
                Debug.LogWarning("Bool can't be changed, no case provided");
                return State.Failure;
        }
        return State.Success;
    }
    
}
