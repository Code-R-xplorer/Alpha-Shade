using System;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class KeyCard : MonoBehaviour
    {
        [HideInInspector]
        public Door door;
        
        

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player)) return;
            KeyCardManager.Instance.KeyCardCollected();
            Destroy(gameObject);
        }
    }
}
