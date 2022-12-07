using TheKiwiCoder;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Guards
{
    public class GuardController : MonoBehaviour
    {
        private BehaviourTreeRunner _behaviourTreeRunner;

        private GameObject _player;
        
        [SerializeField] private float hearingDistance = 5f;

        protected Blackboard blackboard;
        
        protected virtual void Start()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _player = GameObject.FindWithTag("Player");
            blackboard = _behaviourTreeRunner.tree.blackboard;
            GameEvents.Instance.onHeardSomething += Investigate;
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            if (canSeePlayer) blackboard.playerPosition = _player.transform.position;
            blackboard.canSeePlayer = canSeePlayer;
        }

        private void Investigate(Transform investigateTransform, bool investigate)
        {

            if (investigate)
            {
                Debug.Log("Investigate");
                NavMeshPath path = new NavMeshPath();
                NavMesh.CalculatePath(transform.position, 
                    investigateTransform.position, NavMesh.AllAreas, path);
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    float pathLength = Utils.CalculatePathLength(path);
                    Debug.Log("Path Length = " + pathLength);
                    if (pathLength <= hearingDistance)
                    {
                        Debug.Log("Hello");
                        blackboard.investigatePosition = investigateTransform.position;
                        blackboard.investigate = true;
                        return;
                    }
                }
                
            }
            blackboard.investigate = false;
        }
    }
}
