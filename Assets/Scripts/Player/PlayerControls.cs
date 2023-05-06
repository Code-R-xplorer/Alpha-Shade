//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""33419dc0-c93f-4bc8-ac06-42117b6435a9"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6135e90b-e4bb-4927-873f-ff121bc27b21"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5224c5be-3230-44bf-83d8-3af6507c6ab2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""17c044c1-ec92-4115-b403-4878e3cfa53c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""96061071-d2b1-4fa2-80b6-42e4b7b73790"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""e5e80731-df42-4408-a992-bfd51f94a68a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""5b534979-b065-49da-b979-e5e6f96ebd0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Button"",
                    ""id"": ""7896ec01-2942-488e-a535-a052d6ebfd7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleWatch"",
                    ""type"": ""Button"",
                    ""id"": ""5fdfc888-b72f-46ec-90d7-03397369e5f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToggleWatchScreenL"",
                    ""type"": ""Value"",
                    ""id"": ""f5a6a047-a0c6-4f11-9c86-c4c933eb5026"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleWatchScreenR"",
                    ""type"": ""Value"",
                    ""id"": ""bdbfbb6a-0bc7-47f8-9641-b3d1a996c080"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ToggleWatchScreen"",
                    ""type"": ""Button"",
                    ""id"": ""3bec1e28-7d3a-4875-8a30-0789eb21f584"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""996c6a9f-7470-4e4d-8b0f-08f0a4277ab5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""e280423f-a245-42a7-b96a-e259308fdea0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""647545ae-5756-4536-94d9-d3797b53d50b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""78394bb2-f5dd-4595-b7e3-d60e1a3d1153"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8a72113a-ebb3-4c05-8d80-533bdf2a3def"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""72f1b4ba-214f-4610-b848-9965f4d1956b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4180e522-e278-4fae-aba4-c850598b1045"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c5982ae0-337e-4bfe-93a8-22ef4a7cfd5a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a9af3771-ec65-4d27-9877-458cd8bb53b2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f55fcc2-f166-480a-a5bb-bd30ae1e712a"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a28ef432-6f2c-4599-b563-a9501e601e9e"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f81f8fd3-7d4b-4ec4-adcc-0e1c0685ac2a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8998d8b-2302-4627-8f54-e2d70805f8fd"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16d1300f-a811-4102-976e-5b659cd2c205"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e48f9f6-3fb0-4b91-bd36-7ef4b4af7a2f"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWatchScreenL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c84cd0b-e699-4185-b683-2051359b32c5"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWatchScreenR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""385f3358-f3a9-4bec-aec6-6e7dd8e1ed00"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWatchScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""008ec0a0-f903-40a5-bed6-8721206fbe95"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1eb111c-88cf-45be-98c8-0dac55d93231"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f2ced29-f1b9-451d-a1d9-a8c58e2d077a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleWatch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""682c38f8-b9a5-420b-9370-3fa4399a160b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdbcf911-de84-4cf5-ae7c-6867c53f3fc7"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""69528be5-d87c-4c8c-b3a2-8d06979e4571"",
            ""actions"": [
                {
                    ""name"": ""MousePos"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bdb79caa-2cbe-48ff-89b9-c92113367bae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShowMenu"",
                    ""type"": ""Button"",
                    ""id"": ""2aa9984f-342d-4c75-b68d-ab873a2b6311"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""418e7a8f-f7c8-4701-84d6-7b907bdd75a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3e13c54d-6d52-41dc-bbf6-c4ff4c91b4da"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dc50d1a-3128-45d7-9c6d-066ea6dbba51"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c10145b-5f68-4a36-9ac1-073b51cae7f0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Move = m_Controls.FindAction("Move", throwIfNotFound: true);
        m_Controls_Look = m_Controls.FindAction("Look", throwIfNotFound: true);
        m_Controls_Sprint = m_Controls.FindAction("Sprint", throwIfNotFound: true);
        m_Controls_Crouch = m_Controls.FindAction("Crouch", throwIfNotFound: true);
        m_Controls_Interact = m_Controls.FindAction("Interact", throwIfNotFound: true);
        m_Controls_Throw = m_Controls.FindAction("Throw", throwIfNotFound: true);
        m_Controls_Melee = m_Controls.FindAction("Melee", throwIfNotFound: true);
        m_Controls_ToggleWatch = m_Controls.FindAction("ToggleWatch", throwIfNotFound: true);
        m_Controls_ToggleWatchScreenL = m_Controls.FindAction("ToggleWatchScreenL", throwIfNotFound: true);
        m_Controls_ToggleWatchScreenR = m_Controls.FindAction("ToggleWatchScreenR", throwIfNotFound: true);
        m_Controls_ToggleWatchScreen = m_Controls.FindAction("ToggleWatchScreen", throwIfNotFound: true);
        m_Controls_Fire = m_Controls.FindAction("Fire", throwIfNotFound: true);
        m_Controls_Reload = m_Controls.FindAction("Reload", throwIfNotFound: true);
        m_Controls_Pause = m_Controls.FindAction("Pause", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_MousePos = m_UI.FindAction("MousePos", throwIfNotFound: true);
        m_UI_ShowMenu = m_UI.FindAction("ShowMenu", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Move;
    private readonly InputAction m_Controls_Look;
    private readonly InputAction m_Controls_Sprint;
    private readonly InputAction m_Controls_Crouch;
    private readonly InputAction m_Controls_Interact;
    private readonly InputAction m_Controls_Throw;
    private readonly InputAction m_Controls_Melee;
    private readonly InputAction m_Controls_ToggleWatch;
    private readonly InputAction m_Controls_ToggleWatchScreenL;
    private readonly InputAction m_Controls_ToggleWatchScreenR;
    private readonly InputAction m_Controls_ToggleWatchScreen;
    private readonly InputAction m_Controls_Fire;
    private readonly InputAction m_Controls_Reload;
    private readonly InputAction m_Controls_Pause;
    public struct ControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Controls_Move;
        public InputAction @Look => m_Wrapper.m_Controls_Look;
        public InputAction @Sprint => m_Wrapper.m_Controls_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Controls_Crouch;
        public InputAction @Interact => m_Wrapper.m_Controls_Interact;
        public InputAction @Throw => m_Wrapper.m_Controls_Throw;
        public InputAction @Melee => m_Wrapper.m_Controls_Melee;
        public InputAction @ToggleWatch => m_Wrapper.m_Controls_ToggleWatch;
        public InputAction @ToggleWatchScreenL => m_Wrapper.m_Controls_ToggleWatchScreenL;
        public InputAction @ToggleWatchScreenR => m_Wrapper.m_Controls_ToggleWatchScreenR;
        public InputAction @ToggleWatchScreen => m_Wrapper.m_Controls_ToggleWatchScreen;
        public InputAction @Fire => m_Wrapper.m_Controls_Fire;
        public InputAction @Reload => m_Wrapper.m_Controls_Reload;
        public InputAction @Pause => m_Wrapper.m_Controls_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook;
                @Sprint.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnCrouch;
                @Interact.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnInteract;
                @Throw.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnThrow;
                @Melee.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMelee;
                @ToggleWatch.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatch;
                @ToggleWatch.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatch;
                @ToggleWatch.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatch;
                @ToggleWatchScreenL.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenL;
                @ToggleWatchScreenL.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenL;
                @ToggleWatchScreenL.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenL;
                @ToggleWatchScreenR.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenR;
                @ToggleWatchScreenR.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenR;
                @ToggleWatchScreenR.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreenR;
                @ToggleWatchScreen.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreen;
                @ToggleWatchScreen.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreen;
                @ToggleWatchScreen.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnToggleWatchScreen;
                @Fire.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReload;
                @Pause.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @ToggleWatch.started += instance.OnToggleWatch;
                @ToggleWatch.performed += instance.OnToggleWatch;
                @ToggleWatch.canceled += instance.OnToggleWatch;
                @ToggleWatchScreenL.started += instance.OnToggleWatchScreenL;
                @ToggleWatchScreenL.performed += instance.OnToggleWatchScreenL;
                @ToggleWatchScreenL.canceled += instance.OnToggleWatchScreenL;
                @ToggleWatchScreenR.started += instance.OnToggleWatchScreenR;
                @ToggleWatchScreenR.performed += instance.OnToggleWatchScreenR;
                @ToggleWatchScreenR.canceled += instance.OnToggleWatchScreenR;
                @ToggleWatchScreen.started += instance.OnToggleWatchScreen;
                @ToggleWatchScreen.performed += instance.OnToggleWatchScreen;
                @ToggleWatchScreen.canceled += instance.OnToggleWatchScreen;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_MousePos;
    private readonly InputAction m_UI_ShowMenu;
    private readonly InputAction m_UI_Click;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePos => m_Wrapper.m_UI_MousePos;
        public InputAction @ShowMenu => m_Wrapper.m_UI_ShowMenu;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @MousePos.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMousePos;
                @ShowMenu.started -= m_Wrapper.m_UIActionsCallbackInterface.OnShowMenu;
                @ShowMenu.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnShowMenu;
                @ShowMenu.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnShowMenu;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @ShowMenu.started += instance.OnShowMenu;
                @ShowMenu.performed += instance.OnShowMenu;
                @ShowMenu.canceled += instance.OnShowMenu;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnToggleWatch(InputAction.CallbackContext context);
        void OnToggleWatchScreenL(InputAction.CallbackContext context);
        void OnToggleWatchScreenR(InputAction.CallbackContext context);
        void OnToggleWatchScreen(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnMousePos(InputAction.CallbackContext context);
        void OnShowMenu(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
