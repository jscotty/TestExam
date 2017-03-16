//@Author Justin Scott Bieshaar.
//For further questions please read comments or reach me via mail contact@justinbieshaar.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class EdgeDetectionController : MonoBehaviour {

    
    public float sensitivityDepth = 1.0f;
    public float sensitivityNormals = 1.0f;
    public float lumThreshold = 0.2f;
    public float edgeExp = 1.0f;
    public float sampleDist = 1.0f;
    public float edgesOnly = 0.0f;
    public Color edgesOnlyBgColor = Color.black;
    public Color edgesColor = Color.red;

    public Shader edgeDetectShader;
    public Material edgeDetectMaterial = null;

    void SetCameraFlag()
    {
        //			if (mode == EdgeDetectMode.SobelDepth || mode == EdgeDetectMode.SobelDepthThin)
        //				GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        //else 
    }

    void OnEnable()
    {
        SetCameraFlag();
    }

    [ImageEffectOpaque]
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Vector2 sensitivity = new Vector2(sensitivityDepth, sensitivityNormals);
        edgeDetectMaterial.SetVector("_Sensitivity", new Vector4(sensitivity.x, sensitivity.y, 1.0f, sensitivity.y));
        edgeDetectMaterial.SetFloat("_BgFade", edgesOnly);
        edgeDetectMaterial.SetFloat("_SampleDistance", sampleDist);
        edgeDetectMaterial.SetVector("_BgColor", edgesOnlyBgColor);
        edgeDetectMaterial.SetFloat("_Exponent", edgeExp);
        edgeDetectMaterial.SetFloat("_Threshold", lumThreshold);
        edgeDetectMaterial.SetVector("_Color", edgesColor);

        Graphics.Blit(source, destination, edgeDetectMaterial);
    }

}
