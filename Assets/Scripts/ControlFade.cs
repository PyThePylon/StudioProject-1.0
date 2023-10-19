using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFade : MonoBehaviour
{
    SceneFade fade;

    void Start()
    {
        fade = FindObjectOfType<SceneFade>();

        fade.FadeOut();
    }

}
