using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    //Variável que dita se o player tem um escudo para se proteger ou não
    public bool hasShield;

    //Referência do objeto que representa o escudo
    public GameObject shield;

    //Referência ao controlador do jogo GameManager
    public GameManager manager;

    //Referência ao efeito de explosão
    public ParticleSystem explosion;

    //Referência ao controlador dos efeitos sonoros
    public AudioManager audioManager;

    void Update()
    {
        //Determina se o objeto de escudo deve estar ativado ou não conforme a booleana declarada
        shield.SetActive(hasShield);
    }

    //Função que adiciona um escudo ao player
    public void AddShield()
    {
        //Apenas altera a booleana para true
        hasShield = true;
    }

    //Função que destrói o escudo que o player tem
    void LoseShield()
    {
        //Apenas altera a booleana para false
        hasShield = false;
    }      

    //Função de morte da nave do player
    void Die()
    {
        //Instancia o efeito de explosão
        ParticleSystem explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity) as ParticleSystem;

        //Chama a função de tocar o efeito sonoro de destruição do player
        audioManager.PlaySpaceshipExplosionSFX();

        //Invoca a função CallGameOver depois do tempo da duração do efeito de explosão + 1 segundo
        Invoke("CallGameOver", explosionVFX.main.duration + 1f);

        //Desativa o objeto da nave
        gameObject.SetActive(false);
    }

    //Função que chama a função de GameOver do controlador de jogo
    void CallGameOver()
    {
        manager.GameOver();
    }

    //Função ativada quando colidir com algum trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Se o objeto que colidiu tem a tag Missile
        if (collision.gameObject.CompareTag("Missile"))
        {
            //Pega o componente MissileController deste objeto e chama a função de destruição
            collision.gameObject.GetComponent<MissileController>().DestroyMissile();

            //Verficai se a booleana que indica que o jogador tem um escudo é verdadeira
            if (hasShield)
            {
                //Se o jogador tem um escudo, ele é perdido
                LoseShield();
            }
            else
            {
                //Se não, ele morre
                Die();
            }
        }
    }
}
