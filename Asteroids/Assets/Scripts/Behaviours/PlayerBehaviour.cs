using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : BaseObjectBehaviour
{
   
    [SerializeField] private GameObject barrier;
    [SerializeField] private WeaponBehaviour[] weaponBehaviours;
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
        inputActions.PlayerControl.Shoot.performed += OnShootPressed;
        health = data.GetHealth();
        speed = data.GetSpeed();

        weaponBehaviours[0].Setup(manager);
        weaponBehaviours[1].Setup(manager);
        weaponBehaviours[1].Unequip();
        weaponBehaviours[1].gameObject.SetActive(false);

    }

    public void ChangeToSecondaryWeapon()
    {
        weaponBehaviours[0].gameObject.SetActive(false);
        weaponBehaviours[0].Unequip();
        weaponBehaviours[1].gameObject.SetActive(true);
        weaponBehaviours[1].Equip();
    }

    public void StartWaitThenWeaponChangeBack(int waitTime) 
    {
        StartCoroutine(WaitThenWeaponChangeBack(waitTime));
    }

    private IEnumerator WaitThenWeaponChangeBack(int waitTime) 
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Does is ever happen");
        weaponBehaviours[1].gameObject.SetActive(false);
        weaponBehaviours[1].Unequip();
        weaponBehaviours[0].gameObject.SetActive(true);
        weaponBehaviours[0].Equip();
    }

    public void TurnOnBarrier(int numberOfHits)
    { 
        barrier.SetActive(true);
        Barrier barrierBehaviour = barrier.GetComponent<Barrier>();
        barrierBehaviour.Setup(manager, numberOfHits);
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
            //Debug.Log("Ouch!");
            health--;
            if (health < 0) 
            {
                TriggerEvent<PlayerDeadEvent>(new PlayerDeadEvent());
            }
        }
    }

    private void OnDestroy()
    {
        inputActions.PlayerControl.Shoot.performed -= OnShootPressed;
    }
}
