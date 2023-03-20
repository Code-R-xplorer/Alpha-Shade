using System;
using UnityEngine;
using Utilities;

namespace Gun_System
{
    public class GunPickup : MonoBehaviour
    {
        public int index;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GunManager.Instance.GunCollected(index);
                Destroy(gameObject);
            }
        }
    }
}