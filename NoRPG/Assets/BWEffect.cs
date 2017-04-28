using UnityEngine;
using System.Collections;
 
[ExecuteInEditMode]
public class BWEffect : MonoBehaviour {

    private float intensity = 0.0f;
    private Material material;

    public float Intensity {
        get {
            return intensity;
        }

        set {
            intensity = value;
        }
    }

    // Creates a private material used to the effect
    void Awake () {
        material = new Material(Shader.Find("Hidden/BWDiffuse"));
    }

    

    // Postprocess the image
    void OnRenderImage (RenderTexture source, RenderTexture destination) {

        if (GameControl.control.playedIntro) {
            Intensity = 1 - (GameControl.control.gemCount * 0.025f);
        }
        if (Intensity == 0) {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetFloat("_bwBlend", Intensity);
        Graphics.Blit(source, destination, material);
    }
}