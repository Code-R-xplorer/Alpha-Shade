using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class ChangeMaterial : ActionNode
{
    public MaterialChanger.Materials materials;
    protected override void OnStart() {
        blackboard.materialChanger.ChangeMaterial(materials);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return State.Success;
    }
}
