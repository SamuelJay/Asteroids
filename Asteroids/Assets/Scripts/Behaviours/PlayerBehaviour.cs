using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : BaseObjectBehaviour
{
    [SerializeField] private WeaponData weaponData;
    private WeaponBehaviour weaponBehaviour;
    private PlayerData data;
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
        speed = data.GetSpeed();
        weaponBehaviour = GetComponent<WeaponBehaviour>();
        weaponBehaviour.Setup(manager, weaponData);
        inputActions.PlayerControl.Shoot.performed += OnShootPressed;
    }

    protected override void Update()
    {
        base.Update();
        if (inputActions.PlayerControl.Forward.ReadValue<float>() > 0)
        {
            Move();
        }
        if (inputActions.PlayerControl.RotateRight.ReadValue<float>() > 0)
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        if (inputActions.PlayerControl.RotateLeft.ReadValue<float>() > 0)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
    
    private void OnShootPressed(InputAction.CallbackContext obj)
    {
        
        TriggerEvent<ShootPressedEvent>(new ShootPressedEvent());
    }
    
    private void OnTriggerEnter(Collider other)
    {
        AsteroidBehaviour asteroidBehaviour = other.gameObject.GetComponent<AsteroidBehaviour>();
        if (asteroidBehaviour != null)
        {
            Debug.Log("Ouch!");
            health--;
            if (health < 0) 
            {
                TriggerEvent<PlayerDeadEvent>(new PlayerDeadEvent());
            }
        }
    }

}
