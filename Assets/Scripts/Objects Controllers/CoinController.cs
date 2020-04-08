using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe que herda da classe Collectable
public class CoinController : Collectable
{
    //Referencia da classe que cuida do score do jogo
    ScoreManager scoreManager;

    //Valor que vale uma moeda
    public int coinValue;

    public void Awake()
    {
        //Encontra a referência do scoreManager
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

        //Ativa a função de se destruir dentro do tempo de vida estipulado
        Destroy(gameObject, this.timeToDestruct);
    }

    //Função obrigatória declarada na classe mãe
    public override void OnCollected()
    {
        //Ao ser coletada, a moeda chama a função de adicionar score, passando seu valor por parâmetro
        scoreManager.AddScorePerCoin(coinValue);

        //Se destrói imediatamente
        this.DestroyMyself();
    }

    //Função ativada ao receber uam colisão com um trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Verifica se a tag do objeto que colidiu é "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            //Se sim, chama as funções de coleta e de ativação do efeito sonoro
            this.OnCollected();
            this.PlayCollectedCoinSFX();
            
        }
    }
}
