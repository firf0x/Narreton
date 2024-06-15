//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/InputActions/MainController.inputactions
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

public partial class @MainController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainController"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""7f223d7a-d0d1-4149-a779-328046d61a4c"",
            ""actions"": [
                {
                    ""name"": ""Clicks"",
                    ""type"": ""Value"",
                    ""id"": ""f0180120-67c3-4b66-b5e6-75f052003f87"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""02072e25-1db3-41fd-986f-a18f6062f3e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6ea5c914-4d19-4370-ad5d-c5a2ba515187"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clicks"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5aea7dd-db67-411f-b088-55463cf89696"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay"",
            ""id"": ""b687c1c1-be3e-49e6-9c3a-e1587585e3cc"",
            ""actions"": [
                {
                    ""name"": ""MovementCamera"",
                    ""type"": ""Value"",
                    ""id"": ""344c658f-0745-4137-91b3-9e39cbde5b0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MovementPlayer"",
                    ""type"": ""Value"",
                    ""id"": ""d0c91b9b-22bf-4d09-bef0-cc4fcb627418"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ReloadScene"",
                    ""type"": ""Button"",
                    ""id"": ""b2e285e5-7f60-4aef-8eb4-48daa901636c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuActive"",
                    ""type"": ""Button"",
                    ""id"": ""397d32c3-3f3e-4324-b477-cd2cd4275a4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""61e1bc59-6bd1-44c9-a021-acdd767749eb"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""989a5fb0-29c9-41a9-ac89-8c0967277c3f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8f8b604-bb0d-4a3c-82ba-4ee31cfb0e6f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a580c8d3-7850-4f0c-b6a4-08378c801809"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""39c8b560-9483-4848-ab75-f0a28b1b6be4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""51b13f61-97ba-45c6-8cb0-6071e2b6210a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReloadScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""114bccfe-501b-47b4-9da5-986b2068fa4c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuActive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ea76e63e-31ae-416b-bb68-87b434097fd2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementPlayer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""576ced25-3116-413a-bc7d-df0087c216ce"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dbdd96ac-00ac-4a48-ba53-994e02a937f7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cc5beed5-4352-41f5-871d-639f93e0448a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""de89a30d-9931-428f-9231-5aba38890979"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Clicks = m_Mouse.FindAction("Clicks", throwIfNotFound: true);
        m_Mouse_Position = m_Mouse.FindAction("Position", throwIfNotFound: true);
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MovementCamera = m_Gameplay.FindAction("MovementCamera", throwIfNotFound: true);
        m_Gameplay_MovementPlayer = m_Gameplay.FindAction("MovementPlayer", throwIfNotFound: true);
        m_Gameplay_ReloadScene = m_Gameplay.FindAction("ReloadScene", throwIfNotFound: true);
        m_Gameplay_MenuActive = m_Gameplay.FindAction("MenuActive", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private List<IMouseActions> m_MouseActionsCallbackInterfaces = new List<IMouseActions>();
    private readonly InputAction m_Mouse_Clicks;
    private readonly InputAction m_Mouse_Position;
    public struct MouseActions
    {
        private @MainController m_Wrapper;
        public MouseActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Clicks => m_Wrapper.m_Mouse_Clicks;
        public InputAction @Position => m_Wrapper.m_Mouse_Position;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void AddCallbacks(IMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_MouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MouseActionsCallbackInterfaces.Add(instance);
            @Clicks.started += instance.OnClicks;
            @Clicks.performed += instance.OnClicks;
            @Clicks.canceled += instance.OnClicks;
            @Position.started += instance.OnPosition;
            @Position.performed += instance.OnPosition;
            @Position.canceled += instance.OnPosition;
        }

        private void UnregisterCallbacks(IMouseActions instance)
        {
            @Clicks.started -= instance.OnClicks;
            @Clicks.performed -= instance.OnClicks;
            @Clicks.canceled -= instance.OnClicks;
            @Position.started -= instance.OnPosition;
            @Position.performed -= instance.OnPosition;
            @Position.canceled -= instance.OnPosition;
        }

        public void RemoveCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_MouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_MovementCamera;
    private readonly InputAction m_Gameplay_MovementPlayer;
    private readonly InputAction m_Gameplay_ReloadScene;
    private readonly InputAction m_Gameplay_MenuActive;
    public struct GameplayActions
    {
        private @MainController m_Wrapper;
        public GameplayActions(@MainController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementCamera => m_Wrapper.m_Gameplay_MovementCamera;
        public InputAction @MovementPlayer => m_Wrapper.m_Gameplay_MovementPlayer;
        public InputAction @ReloadScene => m_Wrapper.m_Gameplay_ReloadScene;
        public InputAction @MenuActive => m_Wrapper.m_Gameplay_MenuActive;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @MovementCamera.started += instance.OnMovementCamera;
            @MovementCamera.performed += instance.OnMovementCamera;
            @MovementCamera.canceled += instance.OnMovementCamera;
            @MovementPlayer.started += instance.OnMovementPlayer;
            @MovementPlayer.performed += instance.OnMovementPlayer;
            @MovementPlayer.canceled += instance.OnMovementPlayer;
            @ReloadScene.started += instance.OnReloadScene;
            @ReloadScene.performed += instance.OnReloadScene;
            @ReloadScene.canceled += instance.OnReloadScene;
            @MenuActive.started += instance.OnMenuActive;
            @MenuActive.performed += instance.OnMenuActive;
            @MenuActive.canceled += instance.OnMenuActive;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @MovementCamera.started -= instance.OnMovementCamera;
            @MovementCamera.performed -= instance.OnMovementCamera;
            @MovementCamera.canceled -= instance.OnMovementCamera;
            @MovementPlayer.started -= instance.OnMovementPlayer;
            @MovementPlayer.performed -= instance.OnMovementPlayer;
            @MovementPlayer.canceled -= instance.OnMovementPlayer;
            @ReloadScene.started -= instance.OnReloadScene;
            @ReloadScene.performed -= instance.OnReloadScene;
            @ReloadScene.canceled -= instance.OnReloadScene;
            @MenuActive.started -= instance.OnMenuActive;
            @MenuActive.performed -= instance.OnMenuActive;
            @MenuActive.canceled -= instance.OnMenuActive;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IMouseActions
    {
        void OnClicks(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
    public interface IGameplayActions
    {
        void OnMovementCamera(InputAction.CallbackContext context);
        void OnMovementPlayer(InputAction.CallbackContext context);
        void OnReloadScene(InputAction.CallbackContext context);
        void OnMenuActive(InputAction.CallbackContext context);
    }
}
