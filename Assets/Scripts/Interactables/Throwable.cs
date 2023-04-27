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

        private bool _hitGround;

        public void Throw(Transform hand, float throwForce)
        {
            _rb = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            if (_rb != null)
            {
                _rb.sleepThreshold = 0f;
                _rb.mass = 1f;
                _rb.angularDrag = 5f;
                _rb.interpolation = RigidbodyInterpolation.Interpolate;
                _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                _rb.AddForce(Camera.main.transform.up * 5f, ForceMode.Impulse);
                _rb.AddForce(hand.forward * throwForce, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ground))
            {
                if (!_hitGround)
                {
                    AudioManager.Instance.PlayRandom(new []{"coin1", "coin2", "coin3"},transform);
                    _hitGround = true;
                }
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
