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
        private static readonly int SingleDoorAnim = Animator.StringToHash("Single_Door");
        private static readonly int DoubleDoorAnim = Animator.StringToHash("Double_Door");
        private static readonly int SlidingSingleDoorAnim = Animator.StringToHash("Sliding_Single_Door");
        private static readonly int SlidingDoubleDoorAnim = Animator.StringToHash("Sliding_Double_Door");
        private static readonly int Speed = Animator.StringToHash("speed");
        
        private InputManager _inputManager;

        private bool _playerInBounds;
        private bool _open;

        private OffMeshLink _offMeshLink;

        [SerializeField] private Transform investigatePoint;
        [SerializeField] private DoorTypes doorType = DoorTypes.Default;
        [SerializeField] private DoorInteractions doorInteraction = DoorInteractions.Default;

        private bool _hasKeyCard;


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
                switch (doorInteraction)
                {
                    case DoorInteractions.Interact:
                        ToggleDoor(true);
                        break;
                    case DoorInteractions.Automatic:
                        break;
                    case DoorInteractions.KeyCard:
                        if(_hasKeyCard) ToggleDoor(true);
                        break;
                    case DoorInteractions.Default:
                        Debug.LogWarning("No Door Interaction Set!");
                        break;
                }
            }
        }

        private void ToggleDoor(bool playerTriggered)
        {
            if (_open)
            {
                _animator.SetFloat(Speed, -1);
                switch (doorType)
                {
                    case DoorTypes.Single:
                        _animator.Play(SingleDoorAnim, -1,1);
                        break;
                    case DoorTypes.Double:
                        _animator.Play(DoubleDoorAnim, -1,1);
                        break;
                    case DoorTypes.Sliding:
                        _animator.Play(SlidingSingleDoorAnim, -1,1);
                        break;
                    case DoorTypes.SlidingDouble:
                        _animator.Play(SlidingDoubleDoorAnim, -1,1);
                        break;
                    case DoorTypes.Default:
                        Debug.LogWarning("No Door Type Set!");
                        break;
                }
                _open = false;
                _offMeshLink.activated = false;
                GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
            }
            else
            {
                _animator.SetFloat(Speed, 1);
                switch (doorType)
                {
                    case DoorTypes.Single:
                        _animator.Play(SingleDoorAnim, -1,0);
                        break;
                    case DoorTypes.Double:
                        _animator.Play(DoubleDoorAnim, -1,0);
                        break;
                    case DoorTypes.Sliding:
                        _animator.Play(SlidingSingleDoorAnim, -1,0);
                        break;
                    case DoorTypes.SlidingDouble:
                        _animator.Play(SlidingDoubleDoorAnim, -1,0);
                        break;
                    case DoorTypes.Default:
                        Debug.LogWarning("No Door Type Set!");
                        break;
                }
                _open = true;
                _offMeshLink.activated = true;
                GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                switch (doorInteraction)
                {
                    case DoorInteractions.Interact:
                        break;
                    case DoorInteractions.Automatic:
                        ToggleDoor(true);
                        break;
                    case DoorInteractions.KeyCard:
                        break;
                    case DoorInteractions.Default:
                        Debug.LogWarning("No Door Interaction Set!");
                        break;
                }
                _playerInBounds = true;
                
            }

            if (other.CompareTag(Tags.Guard))
            {
                ToggleDoor(false);
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
                switch (doorInteraction)
                {
                    case DoorInteractions.Interact:
                        break;
                    case DoorInteractions.Automatic:
                        ToggleDoor(true);
                        break;
                    case DoorInteractions.KeyCard:
                        break;
                    case DoorInteractions.Default:
                        Debug.LogWarning("No Door Interaction Set!");
                        break;
                }
                _playerInBounds = false;
            }

            if (other.CompareTag(Tags.Guard))
            {
                ToggleDoor(false);
            }
        }

        private enum DoorTypes
        {
            Single,
            Double,
            Sliding,
            SlidingDouble,
            Default
        }

        private enum DoorInteractions
        {
            Interact,
            Automatic,
            KeyCard,
            Default
        }
        
        
        
    }
}
