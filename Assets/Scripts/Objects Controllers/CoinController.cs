using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : Collectable
{
    ScoreManager scoreManager;

    public void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        Destroy(gameObject, this.timeToDestruct);
    }

    public override void OnCollected()
    {
        scoreManager.AddScore();
        this.DestroyMyself();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.OnCollected();
            this.PlayCollectedCoinSFX();
            
        }
    }
}
