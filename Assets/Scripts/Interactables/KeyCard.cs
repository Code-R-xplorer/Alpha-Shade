using System;
using UnityEngine;

namespace Interactables
{
    public class KeyCard : MonoBehaviour
    {
        [HideInInspector]
        public Door door;

        private void OnTriggerEnter(Collider other)
        {
            door.CollectedKeyCard();
            Destroy(gameObject);
        }
    }
}
