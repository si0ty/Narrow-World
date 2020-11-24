using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour
{
    private Material material;
    private SpriteRenderer sprite;
    void Start()
    {
        material = GetComponent<Material>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Texture2D texture = sprite.sprite.texture;
        material.SetTexture("_MainTex", texture);
       
    }
}
