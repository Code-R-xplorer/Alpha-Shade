using System;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Throwable : MonoBehaviour
    {
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.sleepThreshold = 0f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ground))
            {
                GameEvents.Instance.HeardSomething(transform, true);
            }

            if (collision.collider.CompareTag(Tags.Guard))
            {
                Debug.Log("Guard");
                Destroy(gameObject);
            }
        }
    }
}
