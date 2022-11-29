using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class RepeatUntil : DecoratorNode
{
    public bool untilSuccess;
    public bool untilFailure = true;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        switch (child.Update()) {
            case State.Running:
                break;
            case State.Success:
                if (untilSuccess) 
                {
                    return State.Success;
                }
                return State.Running;
            case State.Failure:
                if (untilFailure) 
                {
                    return State.Success;
                }
                return State.Running;
        }
        return State.Running;
    }
}
