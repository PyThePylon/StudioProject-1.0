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
        if(fadeIn == true)
        {
            if(cg.alpha < 1)
            {
                cg.alpha += fadeTime * Time.deltaTime;
                if(cg.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut == true)
        {
            if (cg.alpha >= 0)
            {
                cg.alpha -= fadeTime * Time.deltaTime;
                if (cg.alpha == 0)
                {
                    fadeOut = false;
                }
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
