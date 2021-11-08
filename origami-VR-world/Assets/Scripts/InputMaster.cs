// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Avatar"",
            ""id"": ""faa3f224-3075-4613-bc7f-947b9c958587"",
            ""actions"": [
                {
                    ""name"": ""WalkFWD"",
                    ""type"": ""Button"",
                    ""id"": ""2bf86932-9cf4-407f-a13c-fb69f6fee81b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""de033abc-bd89-4cd7-8a97-deb5be0ae3ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5cd518ed-84f8-43a1-8bbf-a60cb76405ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WalkBWD"",
                    ""type"": ""Button"",
                    ""id"": ""d9e8858e-1a32-4028-bd86-6050f1fe7cf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateUp"",
                    ""type"": ""Button"",
                    ""id"": ""706261a2-39f7-461f-8479-3a765691e237"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpeedUp"",
                    ""type"": ""Button"",
                    ""id"": ""03fc61f8-d907-4500-88f4-a9f136cf6dd8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpeedDown"",
                    ""type"": ""Button"",
                    ""id"": ""c3ba6b59-83fa-4f6f-b89a-0c5a59eda25d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4359c22-84a2-4517-9a0b-4ed5a4f4236e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkFWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb871716-55f0-4182-8d45-c0859e967ca5"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkFWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""512e753f-984f-44b3-aa00-9fc44f4bb8e3"",
                    ""path"": ""<HID::Microsoft Unknown>/hat/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkFWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66d5c143-6755-4dba-a81b-40de70b3f2b4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5de57dbd-6769-409c-bfea-e5efcd01f607"",
                    ""path"": ""<HID::Microsoft Unknown>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f557d78a-808e-46c0-bd8d-11e29e28bffc"",
                    ""path"": ""<HID::Microsoft Unknown>/button8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80bb9ded-3519-42f0-949b-26cccbe4f2d2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f339bc4-6b6a-449b-b052-5b32c1dc1ba7"",
                    ""path"": ""<HID::Microsoft Unknown>/button7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25794d95-493f-4a2c-9b8a-27606ff96f7f"",
                    ""path"": ""<HID::Microsoft Unknown>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ab003a6-0dd7-4833-8c44-849536d7456e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkBWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0a0395a-39e3-4e0e-842d-fc5cc4f30c12"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkBWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1943246e-80cd-4eac-99fc-69d96e7257d7"",
                    ""path"": ""<HID::Microsoft Unknown>/hat/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkBWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85e04384-58e6-4a43-9b73-fcd32960bb32"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dd6b3f7-863c-479a-a120-3defdf520935"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpeedDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""806f5bd9-1e0d-4da9-8096-ec638f26adc5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Avatar
        m_Avatar = asset.FindActionMap("Avatar", throwIfNotFound: true);
        m_Avatar_WalkFWD = m_Avatar.FindAction("WalkFWD", throwIfNotFound: true);
        m_Avatar_RotateRight = m_Avatar.FindAction("RotateRight", throwIfNotFound: true);
        m_Avatar_RotateLeft = m_Avatar.FindAction("RotateLeft", throwIfNotFound: true);
        m_Avatar_WalkBWD = m_Avatar.FindAction("WalkBWD", throwIfNotFound: true);
        m_Avatar_RotateUp = m_Avatar.FindAction("RotateUp", throwIfNotFound: true);
        m_Avatar_SpeedUp = m_Avatar.FindAction("SpeedUp", throwIfNotFound: true);
        m_Avatar_SpeedDown = m_Avatar.FindAction("SpeedDown", throwIfNotFound: true);
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

    // Avatar
    private readonly InputActionMap m_Avatar;
    private IAvatarActions m_AvatarActionsCallbackInterface;
    private readonly InputAction m_Avatar_WalkFWD;
    private readonly InputAction m_Avatar_RotateRight;
    private readonly InputAction m_Avatar_RotateLeft;
    private readonly InputAction m_Avatar_WalkBWD;
    private readonly InputAction m_Avatar_RotateUp;
    private readonly InputAction m_Avatar_SpeedUp;
    private readonly InputAction m_Avatar_SpeedDown;
    public struct AvatarActions
    {
        private @InputMaster m_Wrapper;
        public AvatarActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @WalkFWD => m_Wrapper.m_Avatar_WalkFWD;
        public InputAction @RotateRight => m_Wrapper.m_Avatar_RotateRight;
        public InputAction @RotateLeft => m_Wrapper.m_Avatar_RotateLeft;
        public InputAction @WalkBWD => m_Wrapper.m_Avatar_WalkBWD;
        public InputAction @RotateUp => m_Wrapper.m_Avatar_RotateUp;
        public InputAction @SpeedUp => m_Wrapper.m_Avatar_SpeedUp;
        public InputAction @SpeedDown => m_Wrapper.m_Avatar_SpeedDown;
        public InputActionMap Get() { return m_Wrapper.m_Avatar; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AvatarActions set) { return set.Get(); }
        public void SetCallbacks(IAvatarActions instance)
        {
            if (m_Wrapper.m_AvatarActionsCallbackInterface != null)
            {
                @WalkFWD.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkFWD;
                @WalkFWD.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkFWD;
                @WalkFWD.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkFWD;
                @RotateRight.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateRight;
                @RotateLeft.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateLeft;
                @WalkBWD.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkBWD;
                @WalkBWD.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkBWD;
                @WalkBWD.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnWalkBWD;
                @RotateUp.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateUp;
                @RotateUp.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateUp;
                @RotateUp.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnRotateUp;
                @SpeedUp.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedUp;
                @SpeedUp.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedUp;
                @SpeedDown.started -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedDown;
                @SpeedDown.performed -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedDown;
                @SpeedDown.canceled -= m_Wrapper.m_AvatarActionsCallbackInterface.OnSpeedDown;
            }
            m_Wrapper.m_AvatarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WalkFWD.started += instance.OnWalkFWD;
                @WalkFWD.performed += instance.OnWalkFWD;
                @WalkFWD.canceled += instance.OnWalkFWD;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @WalkBWD.started += instance.OnWalkBWD;
                @WalkBWD.performed += instance.OnWalkBWD;
                @WalkBWD.canceled += instance.OnWalkBWD;
                @RotateUp.started += instance.OnRotateUp;
                @RotateUp.performed += instance.OnRotateUp;
                @RotateUp.canceled += instance.OnRotateUp;
                @SpeedUp.started += instance.OnSpeedUp;
                @SpeedUp.performed += instance.OnSpeedUp;
                @SpeedUp.canceled += instance.OnSpeedUp;
                @SpeedDown.started += instance.OnSpeedDown;
                @SpeedDown.performed += instance.OnSpeedDown;
                @SpeedDown.canceled += instance.OnSpeedDown;
            }
        }
    }
    public AvatarActions @Avatar => new AvatarActions(this);
    public interface IAvatarActions
    {
        void OnWalkFWD(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnWalkBWD(InputAction.CallbackContext context);
        void OnRotateUp(InputAction.CallbackContext context);
        void OnSpeedUp(InputAction.CallbackContext context);
        void OnSpeedDown(InputAction.CallbackContext context);
    }
}
