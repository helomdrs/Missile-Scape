using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    //Referência do componente transform de seu alvo (neste caso, o player)
    Transform target;

    //Referência de seu componente Rigidbody2D
    Rigidbody2D body;

    //Referência do controlador dos efeitos sonoros AudioManager
    AudioManager audioManager;

    //Referência de seu objeto TrailRender
    TrailRenderer trail;

    //Variável de sua velocidade de movimentação
    public float speed;

    //Variável de sua velocidade de rotação
    public float rotateSpeed;

    //Variável de seu tempo de vida
    public float lifeTime;

    void Start()
    {
        //Ao inicio de sua vida no jogo, o objeto busca a referência de todos os objetos declarados
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

        trail = GetComponentInChildren<TrailRenderer>();
    }

    //É utilizado o FixedUpdate devido a manipulação de funções de física
    void FixedUpdate()
    {
        //Enquanto seu tempo de vida for maior que 0
        if(lifeTime > 0f) {

            //Se ele encontrou seu alvo 
            if(target != null)
            {
                //A direção do míssil é definida pela diferença entre sua posição e a do alvo
                Vector2 direction = (Vector2)target.position - body.position;

                //Normalizar o vetor garante que seu valor seja um sem mudar o ângulo da direção
                direction.Normalize();

                //Função matemática que cria um vetor ortogonal entre a direção que deve seguir e a atual, para obter o ângulo de rotação
                float rotateAmout = Vector3.Cross(direction, transform.up).z;

                //Altera a velocidade ângular (de rotação) do corpo rígido
                body.angularVelocity = -rotateAmout * rotateSpeed;

                //A velocidade constante para cima continua
                body.velocity = transform.up * speed;
            }

        } else {
            //Se acabou seu tempo de vida, a função de destruição é chamada
            DestroyMissile();
        }

        //Seu tempo de vida é diminuido gradativamente
        lifeTime -= Time.deltaTime;
    }

    //Função de destruição do míssil
    public void DestroyMissile()
    {
        //Seu componente de sprite é desabilitado para que ele desapareça da tela
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //O mesmo acontece com seu trail
        trail.enabled = false;
        //O objeto é destruído depois de 2 segundos
        Destroy(gameObject, 2f);
    }

    //Função ativada quando há uma colisão com um objeto com trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Se a tag do objeto que colidiu for Missile
        if (collision.gameObject.CompareTag("Missile"))
        {
            //Aciona a função de tocar o efeito sonoro indicado no audioManager
            audioManager.PlayMissileExplosionSFX();

            //Os mísseis se destroem
            DestroyMissile();
        }
    }
}
