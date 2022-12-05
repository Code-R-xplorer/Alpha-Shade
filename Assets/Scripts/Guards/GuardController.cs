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

        private Blackboard _blackboard;
        // Start is called before the first frame update
        void Start()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _player = GameObject.FindWithTag("Player");
            _blackboard = _behaviourTreeRunner.tree.blackboard;
            _blackboard.patrolPoints = patrolPoints;
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            if (canSeePlayer) _blackboard.playerPosition = _player.transform.position;
            _blackboard.canSeePlayer = canSeePlayer;
        }

        public void Investigate(bool investigate, Vector3 investigatePosition)
        {
            if (investigate) _blackboard.investigatePosition = investigatePosition;
            _blackboard.investigate = investigate;
        }
    }
}
