using UnityEngine;
using Utilities;

namespace Tasks
{
    public class EnterArea : MonoBehaviour
    {
        [SerializeField] private int objectiveID = -1;
        [SerializeField] private bool endArea;

        private void OnTriggerEnter(Collider other)
        {
            if (objectiveID == -1) return;
            if (other.CompareTag(Tags.Player))
            {
                if (endArea)
                {
                    ObjectivesManager.Instance.CheckComplete();
                }
                ObjectivesManager.Instance.ObjectiveComplete(objectiveID);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                if(endArea) ObjectivesManager.Instance.CheckComplete();
            }
        }
    }
}
