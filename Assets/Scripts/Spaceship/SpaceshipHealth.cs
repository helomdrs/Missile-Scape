using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    public bool hasShield;

    public GameObject shield;
    public GameManager manager;
    public ParticleSystem explosion;
    public AudioManager audioManager;

    void Update()
    {
        shield.SetActive(hasShield);
    }

    public void AddShield()
    {
        Debug.Log("Has Shield");
        hasShield = true;
    }

    void LoseShield()
    {
        Debug.Log("Shield destroyed");
        hasShield = false;
    }
                

    void Die()
    {
        ParticleSystem explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity) as ParticleSystem;
        audioManager.PlaySpaceshipExplosionSFX();
        Invoke("CallGameOver", explosionVFX.main.duration + 1f);
        gameObject.SetActive(false);
    }

    void CallGameOver()
    {
        manager.GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            collision.gameObject.GetComponent<MissileController>().DestroyMissile();

            if (hasShield)
            {
                LoseShield();
            }
            else
            {
                Die();
            }
        }
    }
}
