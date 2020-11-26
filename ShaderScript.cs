using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour{
    public ComputeShader compute;
    public RenderTexture result;
    int kernel;
    void Start(){
        result = new RenderTexture(256,256,32);
        result.enableRandomWrite = true;
        result.Create();
        kernel = compute.FindKernel("CSMain");
    }

    void Update(){
        compute.SetTexture(kernel, "Result", result);
        compute.Dispatch(kernel,32,32,1);
    }
}
