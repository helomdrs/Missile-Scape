using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    //Velocidade da nave
    public float speed;

    //Velocidade de rotação da nave
    public float rotationSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Aplica uma velocidade constante para frente
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        //Aplica a rotação ao objeto conforme o valor do input do eixo
        transform.Rotate(0f, 0f, -SimpleInput.GetAxis("Horizontal") * rotationSpeed);
    }
}
