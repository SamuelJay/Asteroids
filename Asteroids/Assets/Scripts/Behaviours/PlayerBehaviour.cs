using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : BaseBehaviour
{
    private AppManager appManager => manager as AppManager;
    private GameManager gameManager => appManager.gameManager;
    private InputActions inputActions => gameManager.inputActions;

    public override void Setup(Manager manager)
    {
        base.Setup(manager);
        inputActions.PlayerControl.Forward.performed += OnForwardPressed;
        inputActions.PlayerControl.RotateLeft.performed += OnRotateLeftPressed;
        inputActions.PlayerControl.RotateRight.performed += OnRotateRightPressed;
    }

    private void OnRotateRightPressed(InputAction.CallbackContext obj)
    {
        
    }

    private void OnRotateLeftPressed(InputAction.CallbackContext obj)
    {
        
    }

    private void OnForwardPressed(InputAction.CallbackContext obj)
    {
        
    }
}
