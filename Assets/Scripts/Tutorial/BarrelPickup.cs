using System;
using Tutorial.Sections;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Tutorial
{
    public class BarrelPickup : MonoBehaviour
    {
        [SerializeField] private MovementSection movementSection;
        private void Start()
        {
            movementSection.totalBarrels++;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                movementSection.BarrelCollected();
                Destroy(gameObject);
            }
        }
    }
}