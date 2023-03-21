using System.Collections.Generic;
using UnityEngine;

namespace Guards
{
    public class PatrolGuard : GuardController
    {
        [SerializeField] private List<Transform> patrolPoints;

        public override void Initialize()
        {
            base.Initialize();
            blackboard.patrolPoints = patrolPoints;
        }
    }
}