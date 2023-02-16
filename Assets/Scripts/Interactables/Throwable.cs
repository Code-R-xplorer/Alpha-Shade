using System;
using System.Collections;
using Player;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Throwable : MonoBehaviour
    {
        [SerializeField] private float despawnTime = 10f;
        private Rigidbody _rb;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.sleepThreshold = 0f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ground))
            {
                _rb.drag = 100;
                GameEvents.Instance.HeardSomething(transform, true);
                StartCoroutine(Despawn());
            }

            if (collision.collider.CompareTag(Tags.Guard))
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator Despawn()
        {
            yield return new WaitForSeconds(despawnTime);
            Destroy(gameObject);
        }
    }
}
