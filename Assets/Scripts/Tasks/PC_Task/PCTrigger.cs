using System;
using UI;
using UnityEngine;
using Utilities;

namespace Tasks.PC_Task
{
    public class PCTrigger : MonoBehaviour
    {
        private bool _alreadyTriggered;
        [SerializeField] private int id;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player) && !_alreadyTriggered)
            {
                UIManager.Instance.ShowComputerScreen(id);
                _alreadyTriggered = true;
            }
        }
    }
}