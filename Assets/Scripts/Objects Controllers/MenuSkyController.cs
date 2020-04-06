using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkyController : MonoBehaviour
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

        offset.y +=  Time.deltaTime / parallax;

        texture.mainTextureOffset = offset;
    }
}
