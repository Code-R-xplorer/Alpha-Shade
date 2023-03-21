using System;
using Guards;
using UnityEngine;

namespace Interactables
{
    public class Dart : MonoBehaviour
    {
        public float duration;

        private void Start()
        {
            Destroy(gameObject, 1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Guard"))
            {
                other.GetComponent<GuardController>().Stun(duration);
            }
        }
    }
}