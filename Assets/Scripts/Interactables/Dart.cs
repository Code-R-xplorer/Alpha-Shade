using System;
using Guards;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Dart : MonoBehaviour
    {
        public float duration;

        private void Start()
        {
            Destroy(gameObject, 1f);
            AudioManager.Instance.Play("emp", transform);
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