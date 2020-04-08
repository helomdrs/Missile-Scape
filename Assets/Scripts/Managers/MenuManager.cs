using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Referência ao objeto que indica a pontuação
    public GameObject highscoreIndicator;

    //Referência do objeto de texto da pontuação
    public Text highscoreTxt;

    //Referência do componente AudioSource
    public AudioSource sfx;

    void Start()
    {
        //Verifica se ainda NÃO existe uma chave de Highscore no PlayerPrefs
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            //Se não existe, desativa todo o objeto de pontuação
            highscoreIndicator.SetActive(false);
        } else
        {
            //Se já existe, ativa o objeto indicador de pontuação
            highscoreIndicator.SetActive(true);

            //Se a chave "NewHighscore" apresenta o valor "yes" significa que o jogador alcançou um novo highscore no jogo
            if(PlayerPrefs.GetString("NewHighscore") == "yes")
            {
                //Com isso, um efeito sonoro é tocado uma vez
                sfx.Play();

                //E a chave "NewHighscore" recebe um valor neutro até que o ScoreManager do jogo altere-a novamente
                PlayerPrefs.SetString("NewHighscore", "none");
            }

            //Independente de um novo highscore ou não, o valor de texto do objeto indicador é atualizado para o valor existente na chave "Highscore" do PlayerPrefs
            highscoreTxt.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }

    //Função chamda no botão de iniciar o jogo
    public void StartGame()
    {
        //Carrega a cena Game
        SceneManager.LoadScene("Game");
    }

}
