using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Interactables
{
    public class Door : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int DoorAnim = Animator.StringToHash("Door");
        private static readonly int Speed = Animator.StringToHash("speed");
        
        private InputManager _inputManager;

        private bool _playerInBounds;
        private bool _open;

        private OffMeshLink _offMeshLink;

        [SerializeField] private Transform investigatePoint;


        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _inputManager = InputManager.Instance;
            _offMeshLink = GetComponent<OffMeshLink>();
            _inputManager.OnStartInteract += CheckInteraction;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void CheckInteraction()
        {
            if (_playerInBounds)
            {
                ToggleDoor(true);
            }
        }

        private void ToggleDoor(bool playerTriggered)
        {
            if (_open)
            {
                _animator.SetFloat(Speed, -1);
                _animator.Play(DoorAnim, -1,1);
                _open = false;
                _offMeshLink.activated = false;
                GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
            }
            else
            {
                _animator.SetFloat(Speed, 1);
                _animator.Play(DoorAnim, -1,0 );
                _open = true;
                _offMeshLink.activated = true;
                GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                _playerInBounds = true;
            }

            if (other.CompareTag(Tags.Guard))
            {
                if (!_open)
                {
                    ToggleDoor(false);
                }
            }
        }

        void OnTriggerStay(Collider other){
            if(other.CompareTag(Tags.Player))
            {
                _playerInBounds = true;
            }
        }
 
        void OnTriggerExit(Collider other){
            if(other.CompareTag(Tags.Player))
            {
                _playerInBounds = false;
            }

            if (other.CompareTag(Tags.Guard))
            {
                if (_open)
                {
                    ToggleDoor(false);
                }
            }
        }
        
        
        
    }
}
