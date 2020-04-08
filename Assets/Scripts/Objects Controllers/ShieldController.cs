using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : Collectable
{
    //Referência a classe que gerencia a vida da nave do player
    SpaceshipHealth healthManager;

    public void Awake()
    {
        //Procura o componente do Player declarado
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceshipHealth>();

        //Ativa a destruição do objeto dentro de seu tempo de vida
        Destroy(gameObject, this.timeToDestruct);
    }

    //Função de declaração obrigatória oriunda da classe mãe
    public override void OnCollected()
    {
        //Quando o escudo é coletado, indica a nave que deve levantar o escudo
        healthManager.AddShield();

        //Se destrói ao ser coletado
        this.DestroyMyself();
    }

    //Função ativada quando colidir com algum trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se o objeto que colidiu possuir a tag Player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Dispara a função de coleta do escudo
            this.OnCollected();

            //Indica que o efeito sonoro deve ser coletado
            this.PlayCollectedShieldSFX();
        }
    }
}
