// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""CharacterControls"",
            ""id"": ""de824054-7c00-4640-86e7-556afcc049b7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""7840ac43-c1b1-4997-ae46-a09c0dbebf09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b45fa549-f498-4c6d-9929-25bbade728d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActivateMainhand"",
                    ""type"": ""Value"",
                    ""id"": ""47c7556d-39e0-4090-8792-bfbdbcf58cfe"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""ed3b04fd-8848-4d85-8d97-5e09f7f59a30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector3"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""f8b7da87-32d7-402b-9fa2-e1550dcb7651"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""NormalizeVector3"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActivateOffhand"",
                    ""type"": ""Value"",
                    ""id"": ""bdcf17f0-abfb-45e2-a15b-cf97d516714c"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": ""NormalizeVector3"",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""92df5d70-96fd-49fa-96a1-29e97d195151"",
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
                    ""id"": ""4c4a8f66-e9a0-4dd3-a862-4ef1b225ab72"",
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
                    ""id"": ""f804ed7d-f000-458e-bcef-90370a3ada3d"",
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
                    ""id"": ""259bf94d-905c-4b2d-9d07-1720e2fee2f3"",
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
                    ""id"": ""6000a3c2-941d-4421-8b50-e00d5fb6778a"",
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
                    ""id"": ""4f4fe6fa-4c69-4575-8e71-196d1b225133"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ced65ce4-52d7-44f0-9dc9-e0c20cb45e06"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateMainhand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d7fc787-ac6a-4688-808c-1b364e72c0a3"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e298400-cd96-4057-95a2-a25565b69c18"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc3f17c7-2aff-44a5-a648-1b6ab76ddc00"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActivateOffhand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterControls
        m_CharacterControls = asset.FindActionMap("CharacterControls", throwIfNotFound: true);
        m_CharacterControls_Move = m_CharacterControls.FindAction("Move", throwIfNotFound: true);
        m_CharacterControls_Run = m_CharacterControls.FindAction("Run", throwIfNotFound: true);
        m_CharacterControls_ActivateMainhand = m_CharacterControls.FindAction("ActivateMainhand", throwIfNotFound: true);
        m_CharacterControls_Rotate = m_CharacterControls.FindAction("Rotate", throwIfNotFound: true);
        m_CharacterControls_Interaction = m_CharacterControls.FindAction("Interaction", throwIfNotFound: true);
        m_CharacterControls_ActivateOffhand = m_CharacterControls.FindAction("ActivateOffhand", throwIfNotFound: true);
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

    // CharacterControls
    private readonly InputActionMap m_CharacterControls;
    private ICharacterControlsActions m_CharacterControlsActionsCallbackInterface;
    private readonly InputAction m_CharacterControls_Move;
    private readonly InputAction m_CharacterControls_Run;
    private readonly InputAction m_CharacterControls_ActivateMainhand;
    private readonly InputAction m_CharacterControls_Rotate;
    private readonly InputAction m_CharacterControls_Interaction;
    private readonly InputAction m_CharacterControls_ActivateOffhand;
    public struct CharacterControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public CharacterControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterControls_Move;
        public InputAction @Run => m_Wrapper.m_CharacterControls_Run;
        public InputAction @ActivateMainhand => m_Wrapper.m_CharacterControls_ActivateMainhand;
        public InputAction @Rotate => m_Wrapper.m_CharacterControls_Rotate;
        public InputAction @Interaction => m_Wrapper.m_CharacterControls_Interaction;
        public InputAction @ActivateOffhand => m_Wrapper.m_CharacterControls_ActivateOffhand;
        public InputActionMap Get() { return m_Wrapper.m_CharacterControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterControlsActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterControlsActions instance)
        {
            if (m_Wrapper.m_CharacterControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRun;
                @ActivateMainhand.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateMainhand;
                @ActivateMainhand.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateMainhand;
                @ActivateMainhand.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateMainhand;
                @Rotate.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnRotate;
                @Interaction.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnInteraction;
                @ActivateOffhand.started -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateOffhand;
                @ActivateOffhand.performed -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateOffhand;
                @ActivateOffhand.canceled -= m_Wrapper.m_CharacterControlsActionsCallbackInterface.OnActivateOffhand;
            }
            m_Wrapper.m_CharacterControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @ActivateMainhand.started += instance.OnActivateMainhand;
                @ActivateMainhand.performed += instance.OnActivateMainhand;
                @ActivateMainhand.canceled += instance.OnActivateMainhand;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @ActivateOffhand.started += instance.OnActivateOffhand;
                @ActivateOffhand.performed += instance.OnActivateOffhand;
                @ActivateOffhand.canceled += instance.OnActivateOffhand;
            }
        }
    }
    public CharacterControlsActions @CharacterControls => new CharacterControlsActions(this);
    public interface ICharacterControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnActivateMainhand(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnActivateOffhand(InputAction.CallbackContext context);
    }
}
