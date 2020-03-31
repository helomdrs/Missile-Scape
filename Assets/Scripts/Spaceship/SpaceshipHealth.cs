using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    public bool hasShield;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddShield()
    {
        Debug.Log("Has Shield");
    }

    void LoseShield() { Debug.Log("Shield destroyed"); hasShield = false; }
                

    void Die() { Debug.Log("GameOver"); }

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
