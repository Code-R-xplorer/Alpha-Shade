using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {

        [HideInInspector]
        public Vector3 moveToPosition;
        
        public bool canSeePlayer;
        public bool isChasing;
        
        public Vector3 playerPosition;
        
        public List<Vector3> searchPositions;
        public int searchIndex;
        public bool generateSearchPoints;

        public List<Transform> patrolPoints;
        public int patrolIndex;

        public bool investigate;
        public Vector3 investigatePosition;

        public Vector3 homePosition;
        public Quaternion homeRotation;

    }
}