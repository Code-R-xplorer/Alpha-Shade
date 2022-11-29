using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;

namespace Guards
{
    public class GuardController : MonoBehaviour
    {
    
        private BehaviourTreeRunner _behaviourTreeRunner;

        private GameObject _player;

        [SerializeField] private List<Transform> patrolPoints;
        // Start is called before the first frame update
        void Start()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _player = GameObject.FindWithTag("Player");
            var blackboard = _behaviourTreeRunner.tree.blackboard;
            blackboard.patrolPoints = patrolPoints;
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            var blackboard = _behaviourTreeRunner.tree.blackboard;
            if (canSeePlayer) blackboard.playerPosition = _player.transform.position;
            blackboard.canSeePlayer = canSeePlayer;
        }
    }
}
