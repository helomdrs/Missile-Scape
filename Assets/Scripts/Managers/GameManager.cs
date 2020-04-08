using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variável booleana (verdadeiro ou falso) que indica se o jogo está rodando ou não
    public bool isGameRunning;

    //Objeto inteiro do painél de pause do jogo
    public GameObject pausePanel;

    //Objeto inteiro dos controles do jogo
    public GameObject controls;

    //Objeto inteiro do painél de game over do jogo
    public GameObject gameoverPanel;

    //Componentes de Texto dos objetos que indicam os segundos e minutos do jogo
    public Text secondsTxt, minutesTxt;

    //Variável auxiliar que conta o tempo de pertida
    float timer;

    //Referência a classe ScoreManager para enviar informações
    public ScoreManager scoreManager;
    
    void Start()
    {
        //No começo da partida, os paineis devem estar desativados e os controles ativados
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        controls.SetActive(true);
    }
    
    void Update()
    {
        //Se a booleana isGameRunning é verdadeira, o jogo está rodando
        if (isGameRunning)
        {
            //Se o jogo está rodando, o tempo de partida deve ser contado
            //A variável auxiliar conta o tempo por inteiro
            timer += Time.deltaTime;

            //Os componentes text dos objetos do tipo Text tem seus valores atualizados para strings com duas casas

            //Para representar os minutos, é utilizado a função Mathf.Floor para arrendondar o valor da divisão do tempo atual por 60
            //para o maior valor inteiro menor do que o resultado
            minutesTxt.text = Mathf.Floor(timer / 60).ToString("00");

            //Para representar os segundos, é utilizado a função RoundToInt para arredondar o resto da divisão do tempo atual por 60
            //para o valor inteiro mais próximo
            secondsTxt.text = Mathf.RoundToInt(timer % 60).ToString("00");
        }
    }

    //Função a ser chamada no botão de pause
    public void PauseGame()
    {
        //Atualiza a booleana isGameRunning para false para indicar a todos que o jogo não está rodando neste momento
        isGameRunning = false;

        //O painél de pause é ativado para aparecer na tela
        pausePanel.SetActive(true);

        //A escala de tempo é reduzida a 0, para estar de fato, pausado
        Time.timeScale = 0f;

        //Os controles são desativados para que não apareçam na tela
        controls.SetActive(false);
    }

    //Função a ser chamada nos botões de sair do pause
    public void UnpauseGame()
    {
        //Atualiza a booleana isGameRunning para true para indicar a todos de que o jogo voltou a rodar
        isGameRunning = true;

        //Desativa o painél de pause da tela
        pausePanel.SetActive(false);

        //Atualiza a escala de tempo para 1, fazendo o jogo rodar em sua velocidade normal
        Time.timeScale = 1f;

        //Ativa os controles do jogo
        controls.SetActive(true);
    }

    //Função a ser chamada no botão de sair do menu
    public void QuitToMenu()
    {
        //Atualiza a escala do tempo para 1, para que o jogo rode normalmente
        Time.timeScale = 1f;

        //Carrega a cena de Menu inicial
        SceneManager.LoadScene("MainMenu");
    }

    //Função que controlará o Game Over do jogo
    public void GameOver()
    {
        //Dá o comando ao scoreManager de verificar o Highscore da partida
        scoreManager.SetHighscore();

        //Atualiza a booleana isGameRunning para false para indicar a todos que o jogo não está rodando
        isGameRunning = false;

        //Ativa o painél de Game Over para que este apareça na tela
        gameoverPanel.SetActive(true);

        //Desativa os controles para que eles não apareçam na tela
        controls.SetActive(true);

        //Zera a escala de tempo do jogo
        Time.timeScale = 0f;
    }
}
