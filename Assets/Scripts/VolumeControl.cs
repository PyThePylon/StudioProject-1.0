using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    public AudioSource audioSource;
    private bool increased = false;
    private bool decreased = false;

    void Update()
    {
        // Check if the timeline has reached 13 seconds
        if (Time.time >= 2f && !increased)
        {
            audioSource.volume = 0.8f; // Adjust the volume to your desired level
            increased = true;
        }

        // Check if the timeline has reached 17 seconds
        if (Time.time >= 3f && !decreased)
        {
            audioSource.volume = 0.3f; // Adjust the volume to your desired level
            decreased = true;
        }
    }
}
