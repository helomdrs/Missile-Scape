using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : Collectable
{
    SpaceshipHealth healthManager;

    public void Awake()
    {
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceshipHealth>();
        Destroy(gameObject, this.timeToDestruct);
    }

    public override void OnCollected()
    {
        healthManager.AddShield();
        this.DestroyMyself();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.OnCollected();
            this.PlayCollectedShieldSFX();
        }
    }
}
