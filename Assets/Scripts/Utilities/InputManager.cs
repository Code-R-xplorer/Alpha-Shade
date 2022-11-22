using System;
using UnityEngine;

namespace Utilities
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {
        private PlayerControls _playerControls;

        public delegate void BaseAction();
        public delegate void BoolBaseAction(bool canceled);

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

        
        private void Awake()
        {
            _playerControls = new PlayerControls();

        }
        
        void Start()
        {
            CursorLock(true);
            _playerControls.Controls.Jump.performed += context => StartJumpPrimary();
            _playerControls.Controls.Sprint.started += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Sprint.canceled += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Crouch.started += context => CrouchPrimary(context.canceled);
            _playerControls.Controls.Crouch.canceled += context => CrouchPrimary(context.canceled);
        }

        private void CursorLock(bool locked)
        {
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
