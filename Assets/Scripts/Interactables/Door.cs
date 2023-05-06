using Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
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

        private bool _playerInBounds;
        private bool _open;

        private OffMeshLink _offMeshLink;

        [SerializeField] private string doorName;
        [SerializeField] private Transform investigatePoint;
        [SerializeField] private DoorTypes doorType = DoorTypes.Default;
        [SerializeField] private DoorInteractions doorInteraction = DoorInteractions.Default;
        [SerializeField] private GameObject keyCardReader;

        public bool HasKeyCard { get; private set; }

        public bool locked;


        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _offMeshLink = GetComponent<OffMeshLink>();
            InputManager.Instance.OnStartInteract += CheckInteraction;
            if (doorInteraction == DoorInteractions.KeyCard)
            {
                keyCardReader.SetActive(true);
            }

            // if (GameManager.Instance.tutorial)
            // {
            //     LockDoor();
            // }
        }

        private void CheckInteraction()
        {
            if (locked) return;
            if (_playerInBounds)
            {
                switch (doorInteraction)
                {
                    case DoorInteractions.Interact:
                        ToggleDoor();
                        break;
                    case DoorInteractions.Automatic:
                        break;
                    case DoorInteractions.KeyCard:
                        if (!HasKeyCard)
                        {
                            if (KeyCardManager.Instance.TryKeyCard(doorName)) HasKeyCard = true;
                        }
                        if(HasKeyCard) ToggleDoor();
                        else AudioManager.Instance.Play("doorLocked", transform);
                        break;
                    case DoorInteractions.Default:
                        // Debug.LogWarning("No Door Interaction Set!");
                        break;
                }
            }
        }

        public void LockDoor()
        {
            if(locked) return;
            locked = true;
            if(_open) ToggleDoor();
        }

        public void UnlockDoor()
        {
            locked = false;
        }

        public void OpenDoor()
        {
            if(!_open) ToggleDoor();
        }

        private void ToggleDoor()
        {
            if (_open)
            {
                _animator.SetFloat(Speed, -1);
                AudioManager.Instance.Play("doorClose", transform);
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
                // _offMeshLink.activated = false;
                // GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
            }
            else
            {
                if (locked) return;
                _animator.SetFloat(Speed, 1);
                AudioManager.Instance.Play("doorOpen", transform);
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
                // _offMeshLink.activated = true;
                // GameEvents.Instance.HeardSomething(investigatePoint, playerTriggered);
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
                        ToggleDoor();
                        break;
                    case DoorInteractions.KeyCard:
                        break;
                    case DoorInteractions.Default:
                        // Debug.LogWarning("No Door Interaction Set!");
                        break;
                }

                _playerInBounds = true;

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
                        if(_open) ToggleDoor();
                        break;
                    case DoorInteractions.Automatic:
                        ToggleDoor();
                        break;
                    case DoorInteractions.KeyCard:
                        if(_open) ToggleDoor();
                        break;
                    case DoorInteractions.Default:
                        // Debug.LogWarning("No Door Interaction Set!");
                        break;
                }
                _playerInBounds = false;
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

        private void OnDestroy()
        {
            InputManager.Instance.OnStartInteract -= CheckInteraction;
        }
    }
}
