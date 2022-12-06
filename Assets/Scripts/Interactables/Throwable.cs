using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Throwable : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ground))
            {
                GameEvents.Instance.HeardSomething(transform, true);
            }

            if (collision.collider.CompareTag(Tags.Guard))
            {
                Destroy(gameObject);
            }
        }
    }
}
