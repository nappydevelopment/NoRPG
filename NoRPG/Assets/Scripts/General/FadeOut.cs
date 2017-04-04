using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    public bool fade = false;

    private int fadeDirection = -1;

    void OnGUI () {
        if (fade) {
            alpha += fadeDirection * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
    }

    public void BeginFade(int direction) {
        fadeDirection = direction;
        fade = !fade;
    }

    public void setFade(bool fade) {
        this.fade = fade;
    }
}
