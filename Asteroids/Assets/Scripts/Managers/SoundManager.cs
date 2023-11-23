using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Manager
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playerDied;
    [SerializeField] private AudioClip laserFire;
    [SerializeField] private AudioClip asteroidDestroyed;
    [SerializeField] private AudioClip barrierPowerup;
    [SerializeField] private AudioClip blasterPowerup;

    private bool isMuted;

    [SerializeField] AudioSource musicAudioSource;

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

    public void OnMuteButtonPressed() {

        Debug.Log("Mute button pressed");
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        musicAudioSource.mute = isMuted;
    }
}
