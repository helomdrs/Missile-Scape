using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;

    float spawnRateCounter;

    void Update()
    {
        if(spawnRateCounter < spawnRate)
        {
            spawnRateCounter += Time.deltaTime;
        } else
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(-0.5f, 1.5f), Random.Range(-0.5f, 1.5f)));
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        spawnRateCounter = 0f;
    }

}
