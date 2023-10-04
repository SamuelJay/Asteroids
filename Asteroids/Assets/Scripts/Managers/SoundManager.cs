using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip playerDied;
    [SerializeField] AudioClip laserFire;
    [SerializeField] AudioClip asteroidDestroyed;
    [SerializeField] AudioClip barrierPowerup;
    [SerializeField] AudioClip blasterPowerup;



    public override void Setup(Manager manager) {

        base.Setup(manager);
        StartListeningToEvent<ShootPressedEvent>(OnShootPressed);
        StartListeningToEvent<PlayerDeadEvent>(OnPlayerDead);
        StartListeningToEvent<AsteroidDestroyedEvent>(OnAsteroidDestroyed);
        StartListeningToEvent<BarrierPowerupEvent>(OnBarrierPowerup);
        StartListeningToEvent<BlasterPowerupEvent>(OnBlasterPowerup);
    }

    private void OnBlasterPowerup(object sender, EventArgs e) {

        audioSource.PlayOneShot(blasterPowerup);
    }

    private void OnBarrierPowerup(object sender, EventArgs e) {

        audioSource.PlayOneShot(barrierPowerup);
    }

    private void OnAsteroidDestroyed(object sender, EventArgs e) {

        audioSource.PlayOneShot(asteroidDestroyed);
    }

    private void OnPlayerDead(object sender, EventArgs e) {

       audioSource.PlayOneShot(playerDied);

    }

    private void OnShootPressed(object sender, EventArgs e) {

        audioSource.PlayOneShot(laserFire);
    }


}
