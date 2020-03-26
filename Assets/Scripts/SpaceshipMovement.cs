using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    //Velocidade da nave
    public float speed;
    public float rotationSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        transform.Rotate(0.0f, 0.0f, -SimpleInput.GetAxis("Horizontal") * rotationSpeed);
    }
}
