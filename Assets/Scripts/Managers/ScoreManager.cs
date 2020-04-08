using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Objeto de Texto do Score
    public Text scoreTxt;

    //Referencia a classe GameManager
    public GameManager manager;

    //Variável que guarda o score do jogador
    public float score;

    void Update()
    {
        //Enquanto a booleana isGameRunning for verdadeira
        if (manager.isGameRunning)
        {
            //O score é aumentado conforme o tempo de partida
            score += Time.deltaTime;

            //O valor de texto do objeto do score é atualizado para o valor inteiro mais próximo do score
            scoreTxt.text = Mathf.RoundToInt(score).ToString();
        } 
    }

    //Função que adiciona um valor passado por parâmetro ao score vindo da coleta das moedas
    public void AddScorePerCoin(int coinValue)
    {
        //O valor da moeda é adicionado ao score
        score += coinValue;

        //O valor de texto do objeto do score é atualizado para o valor inteiro mais próximo do score
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
    }

    //Função chamada pelo GameManager onde o ScoreManager configura o highscore no PlayerPrefs
    public void SetHighscore()
    {
        //Se a chave "Highscore" ainda não existe
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            //É criada uma com o valor do atual score
            PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(score));

            //Configura também uma string que funciona como uma booleana, para indicar que um novo highscore foi alcançado
            PlayerPrefs.SetString("NewHighscore", "yes");
        }
        else
        {
            //Se já existe um highscore, é verificado se o valor guardado é menor que o valor do score atual
            if (PlayerPrefs.GetInt("Highscore") < score)
            {
                //Se sim, atualiza o valor da chave Highscore para o valor dos score atual
                PlayerPrefs.SetInt("Highscore", Mathf.RoundToInt(score));

                //Atualiza o valor da chave "booleana" para sim, indicando que o jogador alcançou um novo score
                PlayerPrefs.SetString("NewHighscore", "yes");
            }
            else
            {
                //Se o jogador não alcançou um novo highscore, o valor da "booleana" recebe não
                PlayerPrefs.SetString("NewHighscore", "no");
            }
        }
    }
}
