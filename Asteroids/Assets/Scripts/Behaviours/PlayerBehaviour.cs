using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : BaseBehaviour
{
    private PlayerData data;
    private int speed => data.GetSpeed();
    private AppManager appManager => manager as AppManager;
    private GameManager gameManager => appManager.gameManager;
    private InputActions inputActions => gameManager.inputActions;

    public void Setup(Manager manager, PlayerData data)
    {
        base.Setup(manager);
        this.data = data;
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
