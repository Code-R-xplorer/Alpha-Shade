using System;
using Player;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Throwable : Interactable
    {
        public bool active;
        protected override void Start()
        {
            base.Start();
            var rb = GetComponent<Rigidbody>();
            rb.sleepThreshold = 0f;
        }

        protected override void Interact()
        {
            base.Interact();
            if (active) return;
            if (CanInteract)
            {
                var thrower = Player.GetComponent<Thrower>();
                if (thrower.PickUpItem())
                {
                    Destroy(gameObject);   
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Ground))
            {
                if(active) GameEvents.Instance.HeardSomething(transform, true);
            }

            if (collision.collider.CompareTag(Tags.Guard))
            {
                Destroy(gameObject);
            }
        }
    }
}
