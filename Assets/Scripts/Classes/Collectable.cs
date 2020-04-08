using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe geral dos coletáveis
public abstract class Collectable : MonoBehaviour
{
    //Referência do Audio Manager para enviar as funções de tocar os sons
    AudioManager audioManager;

    //Um tempo de vida que todos os coletáveis terão
    public float timeToDestruct;

    //Função abstrata que deve ser implementada por todos as classes filhas de Collectable
    public abstract void OnCollected();

    private void Start()
    {
        //Ao ser spawnado, procura pela referência do objeto audioManager
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    //Função que será utilizada pelas classes filhas para sua auto-destruição
    public void DestroyMyself()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }

    //Funções a serem utilizadas para chamar os devidos efeitos sonoros no audioManager
    public void PlayCollectedCoinSFX()
    {
        audioManager.PlayCoinCollectedSFX();
    }

    public void PlayCollectedShieldSFX()
    {
        audioManager.PlayShieldCollectedSFX();
    }

}
