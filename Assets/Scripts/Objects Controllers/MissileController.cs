using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    Transform target;
    Rigidbody2D body;

    public float speed;
    public float rotateSpeed;
    public float lifeTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(lifeTime > 0f) {
            //A direção do míssil é definida pela diferença entre sua posição e a do alvo
            Vector2 direction = (Vector2)target.position - body.position;

            //Normalizar o vetor garante que seu valor seja um sem mudar o ângulo da direção
            direction.Normalize();

            //Função matemática que cria um vetor ortogonal entre a direção que deve seguir e a atual, para obter o ângulo de rotação
            float rotateAmout = Vector3.Cross(direction, transform.up).z;

            //Altera a velocidade ângular (de rotação) do corpo rígido
            body.angularVelocity = -rotateAmout * rotateSpeed;

            body.velocity = transform.up * speed;
        } else {
            DestroyMissile();
        }

        lifeTime -= Time.deltaTime;
    }

    public void DestroyMissile()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
