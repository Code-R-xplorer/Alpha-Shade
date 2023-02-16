using UnityEngine;
using UnityEngine.AI;

namespace Utilities
{
    [RequireComponent(typeof(LineRenderer))]
    public class NavigationDebugger : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Assign this to the agent you want to see the path for")]
        private NavMeshAgent agentToDebug;

        private LineRenderer lineRenderer;
        // Start is called before the first frame update
        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!agentToDebug) return;
            if(agentToDebug.hasPath)
            {
                lineRenderer.positionCount = agentToDebug.path.corners.Length;
                lineRenderer.SetPositions(agentToDebug.path.corners);
                lineRenderer.enabled = true;
            }
            else lineRenderer.enabled = false;
        }
    }
}
