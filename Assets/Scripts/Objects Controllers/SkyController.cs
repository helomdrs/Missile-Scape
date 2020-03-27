using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    //Diferença de velocidade entre a movimentação do player e do offset do céu
    public float parallax = 2f;

    MeshRenderer mesh;
    Material texture;
    Vector2 offset;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        texture = mesh.material;
    }


    void Update()
    {
        offset = texture.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parallax;
        offset.y = transform.position.y / transform.localScale.y / parallax;

        texture.mainTextureOffset = offset;
    }
}
