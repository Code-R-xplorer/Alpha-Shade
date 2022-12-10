using System;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Interactable : MonoBehaviour
    {
        private InputManager _inputManager;
        [SerializeField] private float interactRange = 5f;
        protected GameObject Player;
        protected bool CanInteract;

        protected virtual void Start()
        {
            _inputManager = InputManager.Instance;
            _inputManager.OnStartInteract += Interact;
        }

        protected virtual void Interact()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, interactRange);
            Debug.Log(hits.Length);
            
            foreach (var hit in hits)
            {
                Debug.Log(hit.tag);
                if (hit.CompareTag(Tags.Player))
                {
                    CanInteract = true;
                    Player = hit.transform.parent.gameObject;
                    return;
                }
            }
            CanInteract = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactRange);
        }

        private void OnDestroy()
        {
            _inputManager.OnStartInteract -= Interact;
        }
    }
}