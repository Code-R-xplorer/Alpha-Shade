using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class WaitAtPosition : ActionNode
{
    public float duration = 1;
    public GuardPositions guardPositions;
    private Vector3 _waitPos;
    float _startTime;
    private bool _doNotWait;
    protected override void OnStart()
    {
        _doNotWait = false;
        _startTime = Time.time;
        switch (guardPositions)
        {
            case GuardPositions.Investigate:
                _waitPos = blackboard.investigatePosition;
                _waitPos = new Vector3(_waitPos.x, _waitPos.y + 1, _waitPos.z);
                break;
            case GuardPositions.Patrol:
                int patrolIndex = blackboard.patrolIndex - 1;
                if (patrolIndex == -1) patrolIndex = blackboard.patrolPoints.Count - 1;
                _waitPos = blackboard.patrolPoints[patrolIndex].position;
                _waitPos = new Vector3(_waitPos.x, _waitPos.y + 1, _waitPos.z);
                float value = Random.value;
                
                if (value > 0.7f)
                {
                    _doNotWait = true;
                }
                break;
            case GuardPositions.Search:
                int searchIndex = blackboard.searchIndex - 1;
                if (searchIndex == -1) searchIndex = 0;
                _waitPos = blackboard.searchPositions[searchIndex];
                _waitPos = new Vector3(_waitPos.x, _waitPos.y + 1, _waitPos.z);
                break;
            case GuardPositions.Default:
                Debug.LogWarning("No Position provided");
                break;
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (_doNotWait) return State.Success;
        float timeRemaining = Time.time - _startTime;
        if (_waitPos == Vector3.zero) return State.Failure;
        
        if (timeRemaining > duration) {
            return State.Success;
        }

        if (blackboard.canSeePlayer) return State.Success;
        if (guardPositions != GuardPositions.Investigate && blackboard.investigate) return State.Success;

        context.transform.position = _waitPos;
        context.agent.destination = _waitPos;
        return State.Running;
    }

    public enum GuardPositions
    {
        Investigate,
        Patrol,
        Search,
        Default
    }
}
