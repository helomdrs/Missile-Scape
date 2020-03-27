using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    AudioManager audioManager;
    public abstract void OnCollected();

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void DestroyMyself()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }

    public void PlayCollectedCoinSFX()
    {
        audioManager.PlayCoinCollectedSFX();
    }

    public void PlayCollectedShieldSFX()
    {
        audioManager.PlayShieldCollectedSFX();
    }

}
