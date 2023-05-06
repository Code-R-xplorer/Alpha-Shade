using System;
using UnityEngine;
using Utilities;

namespace Tutorial
{
    public class CompleteTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                TutorialManager.Instance.TutorialComplete();
            }
            
        }
    }
}