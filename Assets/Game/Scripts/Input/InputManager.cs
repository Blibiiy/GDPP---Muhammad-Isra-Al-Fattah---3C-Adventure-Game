using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<bool> OnSprintInput;
    public Action OnJumpInput;

    public Action OnClimbInput;

    public Action OnCancelClimb;

    public Action OnChangePOV;

    public Action OnCrouchInput;

    public Action OnGlideInput;
    public Action OnCancelGlide;

    public Action OnPunchInput;

    public Action OnMainMenuInput;
    private void Update()
    {
        CheckMovementInput();
        CheckSprintInput();
        CheckJumpInput();
        CheckClimbInput();
        CheckCancelInput();
        CheckChangePOVInput();
        CheckCrouchInput();
        CheckGlideInput();
        CheckPunchInput();
        CheckMainMenuInput();
    }

    private void CheckCancelInput()
    {
        bool isPressCancelInput = Keyboard.current.cKey.wasPressedThisFrame;
        if (isPressCancelInput)
        {
            if (OnCancelClimb != null)
            {
                OnCancelClimb();
            }
            if (OnCancelGlide != null)
            {
                OnCancelGlide();
            }
        }
    }

    private void CheckMovementInput()
    {
        float verticalAxis = 0;
        float horizontalAxis = 0;

        if(Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) verticalAxis += 1;
            if (Keyboard.current.sKey.isPressed) verticalAxis -= 1;
            if (Keyboard.current.aKey.isPressed) horizontalAxis -= 1;
            if (Keyboard.current.dKey.isPressed) horizontalAxis += 1;
        }
        Vector2 inputAxis = new Vector2(horizontalAxis, verticalAxis).normalized;

        if(OnMoveInput != null)
        {
            OnMoveInput(inputAxis);
        }
    }

    private void CheckSprintInput()
    {
        bool isHoldSprintInput = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;
        if (isHoldSprintInput)
        {
            if(OnSprintInput != null)
            {
                OnSprintInput(true);
            }
        }
        else
        {
            if(OnSprintInput != null)
            {
                OnSprintInput(false);
            }
        }    
    }

    private void CheckJumpInput()
    {
        bool isPressJumpInput = Keyboard.current.spaceKey.wasPressedThisFrame;
        if (isPressJumpInput)
        {
            if (OnJumpInput != null)
            {
                OnJumpInput();
            }
        }
    }

    private void CheckClimbInput()
    {
        bool isPressClimbInput = Keyboard.current.eKey.wasPressedThisFrame;
        if (isPressClimbInput)
        {
            OnClimbInput();
        }
    }

    private void CheckChangePOVInput()
    {
        bool isPressChangePOVInput = Keyboard.current.qKey.wasPressedThisFrame;
        if (isPressChangePOVInput)
        {
            if (OnChangePOV != null)
            {
                OnChangePOV();
            }
        }
    }

    private void CheckCrouchInput()
    {
        bool isPressCrouchInput = Keyboard.current.leftCtrlKey.wasPressedThisFrame || Keyboard.current.rightCtrlKey.wasPressedThisFrame;
        if (isPressCrouchInput)
        {
            OnCrouchInput();
        }
    }

    private void CheckGlideInput()
    {
        bool isPressGlideInput = Keyboard.current.gKey.wasPressedThisFrame;
        if (isPressGlideInput)
        {
            if (OnGlideInput != null)
            {
                OnGlideInput();
            }
        }
    }

    private void CheckPunchInput()
    {
        bool isPressPunchInput = Mouse.current.rightButton.wasPressedThisFrame;
        if (isPressPunchInput)
        {
            OnPunchInput();
        }
    }

    private void CheckMainMenuInput()
    {
        bool isPressMainMenuInput = Keyboard.current.escapeKey.wasPressedThisFrame;
        if (isPressMainMenuInput)
        {
            if (OnMainMenuInput != null)
            {
                OnMainMenuInput();
            }
        }
    }
}