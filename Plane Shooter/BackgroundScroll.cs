using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshRenderer;
    public float scrollSpeed = 0.1f;

    void Update()
    {
        // in the Renderer we have material property and its offset
        // scroll background using offset property, it is a vector2 property
        meshRenderer.material.mainTextureOffset += new Vector2(0f, scrollSpeed * Time.deltaTime);
    }
}