using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{

    public CanvasGroup cg;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float fadeTime;

    void Update()
    {
        Debug.Log("Fade in: " + fadeIn);
        Debug.Log("Fade out: " + fadeOut);
        if (fadeIn)
        {
            cg.alpha = Mathf.Clamp(cg.alpha + Time.deltaTime / fadeTime, 0, 1);
            if (cg.alpha >= 1)
            {
                fadeIn = false;
            }
        }

        if (fadeOut)
        {
            cg.alpha = Mathf.Clamp(cg.alpha - Time.deltaTime / fadeTime, 0, 1);
            if (cg.alpha <= 0)
            {
                fadeOut = false;
            }
        }
    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }
}
