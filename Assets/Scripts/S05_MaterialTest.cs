using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S05_MaterialTest : MonoBehaviour
{
    private Renderer renderer_comp;

    // Start is called before the first frame update
    void Start()
    {
        renderer_comp = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            renderer_comp.material.color = Color.red;
        if (Input.GetKeyDown(KeyCode.G))
            renderer_comp.material.color = Color.green;
        if (Input.GetKeyDown(KeyCode.B))
            renderer_comp.material.color = Color.blue;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            renderer_comp.material.SetFloat("_Mode", 0);
            renderer_comp.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            renderer_comp.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            renderer_comp.material.SetInt("_ZWrite", 1);
            renderer_comp.material.EnableKeyword("_ALPHATEST_ON");
            renderer_comp.material.DisableKeyword("_ALPHABLEND_ON");
            renderer_comp.material.DisableKeyword("_ALPHAPREMUlTIPLY_ON");
            renderer_comp.material.renderQueue = -1;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            renderer_comp.material.SetFloat("_Mode", 1);
            renderer_comp.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            renderer_comp.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            renderer_comp.material.SetInt("_ZWrite", 1);
            renderer_comp.material.DisableKeyword("_ALPHATEST_ON");
            renderer_comp.material.DisableKeyword("_ALPHABLEND_ON");
            renderer_comp.material.DisableKeyword("_ALPHAPREMUlTIPLY_ON");
            renderer_comp.material.renderQueue = 2450;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            renderer_comp.material.SetFloat("_Mode", 2);
            renderer_comp.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            renderer_comp.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderer_comp.material.SetInt("_ZWrite", 0);
            renderer_comp.material.DisableKeyword("_ALPHATEST_ON");
            renderer_comp.material.EnableKeyword("_ALPHABLEND_ON");
            renderer_comp.material.DisableKeyword("_ALPHAPREMUlTIPLY_ON");
            renderer_comp.material.renderQueue = 3000;            
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            renderer_comp.material.SetFloat("_Mode", 3);
            renderer_comp.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            renderer_comp.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderer_comp.material.SetInt("_ZWrite", 0);
            renderer_comp.material.DisableKeyword("_ALPHATEST_ON");
            renderer_comp.material.DisableKeyword("_ALPHABLEND_ON");
            renderer_comp.material.EnableKeyword("_ALPHAPREMUlTIPLY_ON");
            renderer_comp.material.renderQueue = 3000;            
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Texture albedoTex = Resources.Load("Textrue/blahblah") as Texture;
            renderer_comp.material.SetTexture("_MainTex", albedoTex);
        }

    }
}
