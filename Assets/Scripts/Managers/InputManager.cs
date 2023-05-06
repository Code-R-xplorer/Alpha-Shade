using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

namespace Managers
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
        public Vector2 MousePos { get; private set; }
        
        public event BoolBaseAction OnSprint;
        public event BoolBaseAction OnCrouch;
        public event BoolDoubleBaseAction OnThrow;
        public event BoolDoubleBaseAction OnMelee;
        public event BoolBaseAction OnFire;
        public event BaseAction OnReload;

        public event BaseAction OnStartInteract;
        public event BaseAction OnStartToggleWatch;
        public event BaseAction OnStartToggleWatchScreen;
        public event BaseAction OnStartToggleWatchScreenL;
        public event BaseAction OnStartToggleWatchScreenR;

        public event BoolBaseAction OnToggleMenu;
        public event BaseAction OnClick;
        public event BaseAction OnPause;

        public Action OnAnyButtonPress;
        private void AnyButtonPress() {OnAnyButtonPress?.Invoke();}

        private bool _buttonPressed;

        
        private void Awake()
        {
            Instance = this;
            _playerControls = new PlayerControls();
            
            InputSystem.onEvent +=
                (eventPtr, device) =>
                {
                    if (!eventPtr.IsA<StateEvent>() && !eventPtr.IsA<DeltaStateEvent>())
                        return;
                    var controls = device.allControls;
                    var buttonPressPoint = InputSystem.settings.defaultButtonPressPoint;
                    for (var i = 0; i < controls.Count; ++i)
                    {
                        var control = controls[i] as ButtonControl;
                        if (control == null || control.synthetic || control.noisy)
                            continue;
                        if (control.ReadValueFromEvent(eventPtr, out var value) && value >= buttonPressPoint)
                        {
                            _buttonPressed = true;
                            break;
                        }
                    }
                };

        }
        
        void Start()
        {
            CursorLock(true);
            _playerControls.Controls.Sprint.started += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Sprint.canceled += context => SprintPrimary(context.canceled);
            _playerControls.Controls.Crouch.started += context => CrouchPrimary(context.canceled);
            _playerControls.Controls.Crouch.canceled += context => CrouchPrimary(context.canceled);
            _playerControls.Controls.Throw.started += context => ThrowPrimary(context.canceled, context.duration);
            _playerControls.Controls.Throw.canceled += context => ThrowPrimary(context.canceled, context.duration);
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
            _playerControls.Controls.Pause.performed += _ => PausePrimary();
            _playerControls.UI.ShowMenu.started += context => ToggleMenuPrimary(context.canceled);
            _playerControls.UI.ShowMenu.canceled += context => ToggleMenuPrimary(context.canceled);
            _playerControls.UI.Click.performed += _ => ClickPrimary();
        }

        public void CursorLock(bool locked)
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
            MousePos = _playerControls.UI.MousePos.ReadValue<Vector2>();
            if (!_buttonPressed) return;
            AnyButtonPress();
            _buttonPressed = false;

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

        private void ThrowPrimary(bool canceled, double duration)
        {
            OnThrow?.Invoke(canceled, duration);
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

        private void ToggleMenuPrimary(bool canceled)
        {
            OnToggleMenu?.Invoke(canceled);
        }

        private void ClickPrimary()
        {
            OnClick?.Invoke();
        }

        private void PausePrimary()
        {
            OnPause?.Invoke();
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
