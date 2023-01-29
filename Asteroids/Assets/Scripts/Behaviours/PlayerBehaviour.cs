using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : BaseBehaviour
{
    private PlayerData data;
    private int speed => data.GetSpeed();
    private int rotationSpeed => data.GetRotationSpeed();
    private int health; 
    private AppManager appManager => manager as AppManager;
    private GameManager gameManager => appManager.gameManager;
    private InputActions inputActions => gameManager.inputActions;

    public void Setup(Manager manager, PlayerData data)
    {
        base.Setup(manager);
        this.data = data;
        health = data.GetHealth();
    }
    void Update()
    {
        if (inputActions.PlayerControl.Forward.ReadValue<float>() > 0)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (inputActions.PlayerControl.RotateRight.ReadValue<float>() > 0)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        if (inputActions.PlayerControl.RotateLeft.ReadValue<float>() > 0)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
       
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        
        if (screenPosition.x < 0)
        {
            screenPosition.x = 1;
        }

        if (screenPosition.x > 1)
        {
            screenPosition.x = 0;
        }

        if (screenPosition.y > 1)
        {
            screenPosition.y = 0;
        }

        if (screenPosition.y < 0)
        {
            screenPosition.y = 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(screenPosition); 
    }
}
