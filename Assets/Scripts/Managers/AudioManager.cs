using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource spaceshipEngine, generalSFX;
    public AudioClip[] soundEffects;
    public GameManager manager;

    void Update()
    {
        spaceshipEngine.enabled = manager.isGameRunning;
    }

    public void PlayCoinCollectedSFX()
    {
        generalSFX.PlayOneShot(soundEffects[0]);
    }

    public void PlayShieldCollectedSFX()
    {
        generalSFX.PlayOneShot(soundEffects[1]);
    }

    public void PlayMissileExplosionSFX()
    {
        generalSFX.PlayOneShot(soundEffects[2]);
    }

    public void PlaySpaceshipExplosionSFX()
    {
        generalSFX.PlayOneShot(soundEffects[2]);
        spaceshipEngine.volume = 0f;
    }
}
