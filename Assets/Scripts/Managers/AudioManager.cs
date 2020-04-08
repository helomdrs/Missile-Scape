using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Armazenamento dos dois componentes AudioSource's do objeto
    public AudioSource spaceshipEngine, generalSFX;

    //Array que conterá todos os efeitos sonoros
    public AudioClip[] soundEffects;

    //Referência da classe GameManager
    public GameManager manager;

    void Update()
    {
        //Devido a continuidade do efeito sonoro do motor da nave, este componente deve estar ativado enquanto o jogo esta rodando
        //Essa informação é obtida através da booleana presente no GameManager isGameRunning
        spaceshipEngine.enabled = manager.isGameRunning;
    }

    //Toca o som da coleta da moeda
    public void PlayCoinCollectedSFX()
    {
        //O efeito sonoro da moeda é o primeiro elemento do array, no índice 0
        generalSFX.PlayOneShot(soundEffects[0]);
    }

    //Toca o som da coleta do escudo
    public void PlayShieldCollectedSFX()
    {
        //O efeito sonoro do escudo é o seguindo elemento do array, no índice 1
        generalSFX.PlayOneShot(soundEffects[1]);
    }

    //Toca o som da explosão do míssil
    public void PlayMissileExplosionSFX()
    {
        //O efeito sonoro da explosão é o terceiro elemento do array, no índice 2
        generalSFX.PlayOneShot(soundEffects[2]);
    }
    
    //Toca o som da explosão da nave do player
    public void PlaySpaceshipExplosionSFX()
    {
        //O efeito sonoro é o mesmo do míssil, sendo o terceiro elemento do array, no índice 2
        generalSFX.PlayOneShot(soundEffects[2]);

        //Zera o volume do motor da nave
        spaceshipEngine.volume = 0f;
    }
}
