using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Utilities
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        private PlayerControls _playerControls;

        public delegate void BaseAction();
        public delegate void BoolBaseAction(bool canceled);
        public delegate void BoolDoubleBaseAction(bool canceled, double duration);

        public Vector2 MovementInput { get; private set; }
        public Vector2 LookInput { get; private set; }
    
        // Input Action Setup Example
        // public event BaseAction OnStartJump;
        // private void StartJumpPrimary()
        // {
        //     OnStartJump?.Invoke();
        // }

        public event BaseAction OnStartJump;
        public event BoolBaseAction OnSprint;
        public event BoolBaseAction OnCrouch;
        public event BoolBaseAction OnThrow;
        public event BoolDoubleBaseAction OnMelee;
        public event BoolBaseAction OnFire;
        public event BaseAction OnReload;

        public event BaseAction OnStartInteract;
        public event BaseAction OnStartToggleWatch;
        public event BaseAction OnStartToggleWatchScreen;
        public event BaseAction OnStartToggleWatchScreenL;
        public event BaseAction OnStartToggleWatchScreenR;

        
        private void Awake()
        {
            Instance = this;
            _playerControls = new PlayerControls();

        }
        
        void Start()
        {
            CursorLock(true);
            _playerControls.Controls.Jump.performed += _ => StartJumpPrimary();
            _playerControls.Controls.Sprint.started += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Sprint.canceled += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Crouch.started += context => CrouchPrimary(context.canceled);
            _playerControls.Controls.Crouch.canceled += context => CrouchPrimary(context.canceled);
            _playerControls.Controls.Throw.started += context => ThrowPrimary(context.canceled);
            _playerControls.Controls.Throw.canceled += context => ThrowPrimary(context.canceled);
            _playerControls.Controls.Melee.started += context => MeleePrimary(context.canceled, context.duration);
            _playerControls.Controls.Melee.canceled += context => MeleePrimary(context.canceled, context.duration);
            _playerControls.Controls.Fire.started += context => FirePrimary(context.canceled); 
            _playerControls.Controls.Fire.canceled += context => FirePrimary(context.canceled);
            _playerControls.Controls.Reload.performed += _ => ReloadPrimary();
            _playerControls.Controls.Interact.performed += _ => StartInteractPrimary();
            _playerControls.Controls.ToggleWatch.performed += _ => StartToggleWatchPrimary();
            _playerControls.Controls.ToggleWatchScreen.performed += _ => StartToggleWatchScreenPrimary();
            _playerControls.Controls.ToggleWatchScreenL.performed += _ => StartToggleWatchScreenLPrimary();
            _playerControls.Controls.ToggleWatchScreenR.performed += _ => StartToggleWatchScreenRPrimary();
        }

        public void CursorLock(bool locked)
        {
            Debug.Log(locked);
            if (locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
        }

        private void Update()
        {
            MovementInput = _playerControls.Controls.Move.ReadValue<Vector2>();
            LookInput = _playerControls.Controls.Look.ReadValue<Vector2>();
        }

        private void StartJumpPrimary()
        {
            OnStartJump?.Invoke();
        }

        private void SprintPrimary(bool canceled)
        {
            OnSprint?.Invoke(canceled);
        }

        private void CrouchPrimary(bool canceled)
        {
            OnCrouch?.Invoke(canceled);
        }
        private void MeleePrimary(bool canceled, double duration)
        {
            OnMelee?.Invoke(canceled, duration);
        }

        private void FirePrimary(bool canceled)
        {
            OnFire?.Invoke(canceled);
        }

        private void ReloadPrimary()
        {
            OnReload?.Invoke();
        }

        private void StartInteractPrimary()
        {
            OnStartInteract?.Invoke();
        }

        private void ThrowPrimary(bool canceled)
        {
            OnThrow?.Invoke(canceled);
        }

        private void StartToggleWatchPrimary()
        {
            OnStartToggleWatch?.Invoke();
        }

        private void StartToggleWatchScreenPrimary()
        {
            OnStartToggleWatchScreen?.Invoke();
        }

        private void StartToggleWatchScreenLPrimary()
        {
            OnStartToggleWatchScreenL?.Invoke();
        }

        private void StartToggleWatchScreenRPrimary()
        {
            OnStartToggleWatchScreenR?.Invoke();
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }
    
        private void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}
