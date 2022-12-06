using System.Collections.Generic;
using TheKiwiCoder;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Utilities;

namespace Guards
{
    public class GuardController : MonoBehaviour
    {
    
        private BehaviourTreeRunner _behaviourTreeRunner;

        private GameObject _player;

        [SerializeField] private List<Transform> patrolPoints;
        [SerializeField] private float hearingDistance = 5f;

        private Blackboard _blackboard;
        // Start is called before the first frame update
        void Start()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _player = GameObject.FindWithTag("Player");
            _blackboard = _behaviourTreeRunner.tree.blackboard;
            _blackboard.patrolPoints = patrolPoints;
            GameEvents.Instance.onHeardSomething += Investigate;
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            if (canSeePlayer) _blackboard.playerPosition = _player.transform.position;
            _blackboard.canSeePlayer = canSeePlayer;
        }

        public void Investigate(Transform investigateTransform, bool investigate)
        {

            if (investigate)
            {
                NavMeshPath path = new NavMeshPath();
                NavMesh.CalculatePath(transform.position, 
                    investigateTransform.position, NavMesh.AllAreas, path);
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    float pathLength = Utils.CalculatePathLength(path);
                    if (pathLength <= hearingDistance)
                    {
                        _blackboard.investigatePosition = investigateTransform.position;
                        _blackboard.investigate = true;
                        return;
                    }
                }
                
            }
            _blackboard.investigate = false;
        }
    }
}
