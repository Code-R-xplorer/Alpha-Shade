using System.Collections.Generic;
using UnityEngine;

namespace Guards
{
    public class PatrolGuard : GuardController
    {
        [SerializeField] private List<Transform> patrolPoints;

        protected override void Start()
        {
            base.Start();
            blackboard.patrolPoints = patrolPoints;
        }

        public void SetPatrolPoints(List<Transform> points)
        {
            patrolPoints = points;
        }
    }
}