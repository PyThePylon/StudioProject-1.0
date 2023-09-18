using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI volumeText;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Volume");
        volumeText.text = "Volume: " + (slider.value * 100).ToString("F1") + "%";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setVolume()
    {
        AudioListener.volume = slider.value;
        volumeText.text = "Volume: " + (slider.value * 100).ToString("F1") + "%";
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
