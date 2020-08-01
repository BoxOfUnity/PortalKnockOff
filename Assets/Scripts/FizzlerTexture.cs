using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FizzlerTexture : MonoBehaviour
{

    public float textureSpeed = 3f;
    private Renderer textureRenderer = new Renderer();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offSet = Time.deltaTime * textureSpeed;
        //textureRenderer.material.SetTextureOffset("_MainTex", new Vector2(offSet, 0f));


    }
}
