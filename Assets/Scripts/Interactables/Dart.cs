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
            Debug.Log("Hello");
            Destroy(gameObject, 1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Guard"))
            {
                Debug.Log("enter");
                other.GetComponent<GuardController>().Stun(duration);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Guard"))
            {
                Debug.Log("stay");
            }
        }
    }
}