using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class Crate : Interactable
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject spawnPrefab;

        private Animator _animator;
        private static readonly int Open = Animator.StringToHash("Open");
        private bool _opened;
        private GameObject _spawnedObject;
        
        protected override void Start()
        {
            base.Start();
            _animator = GetComponent<Animator>();
        }

        protected override void Interact()
        {
            base.Interact();
            if (!CanInteract || _opened) return;
            _animator.Play(Open, -1, 0f);
            _spawnedObject = Instantiate(spawnPrefab, spawnPoint);
            _opened = true;
        }

        public void EnablePickup()
        {
            _spawnedObject.GetComponent<BoxCollider>().enabled = true;
        }

        public bool IsOpen()
        {
            return _opened;
        }
        
    }
}