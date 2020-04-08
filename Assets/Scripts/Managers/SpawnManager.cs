using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Recebe o objeto a ser instanciado
    public GameObject prefab;

    //Frequência em segundos que este objeto será instanciado no jogo
    public float spawnRate;

    //Contador auxiliar da frequência de spawn
    float spawnRateCounter;

    void Update()
    {
        //Se o contador auxiliar for menor que a frequência estipulada
        if(spawnRateCounter < spawnRate)
        {
            //O contador aumenta conforme o tempo de partida
            spawnRateCounter += Time.deltaTime;
        } else
        {
            //Se não (sendo igual ou maior), dispara a função de instanciar um novo objeto
            Spawn();
        }
    }

    //Função que instancia um novo objeto
    void Spawn()
    {
        //Calcula primeiro a posição onde o objeto será instanciado, utilizando a função ViewportToWorldPoint, que pega um ponto na Viewport
        //e o transforma em um ponto do mundo, com métricas e valores diferentes, com valores aleatórios entre os quatro lados da tela
        Vector2 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(-0.5f, 1.5f), Random.Range(-0.5f, 1.5f)));

        //Instancia o objeto na posição calculada
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        //Zera o contador auxiliar
        spawnRateCounter = 0f;
    }

}
