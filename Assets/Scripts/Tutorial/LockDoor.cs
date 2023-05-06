using System;
using Interactables;
using UnityEngine;
using Utilities;

namespace Tutorial
{
    public class LockDoor : MonoBehaviour
    {
        public Door door;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                door.LockDoor();
                TutorialManager.Instance.UpdateObjectiveText("");
            }
        }
    }
}