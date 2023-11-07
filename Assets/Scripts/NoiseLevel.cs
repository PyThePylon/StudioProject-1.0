using UnityEngine;
using System.Collections.Generic;

public class NoiseLevel : MonoBehaviour
{
    public List<AudioSource> audibleAudioSources = new List<AudioSource>();
    public float overstimulationThreshold = 1.5f;
    public float overstimulationIntensity = 0.5f;

    // Update is called once per frame
    void Update()
    {
        audibleAudioSources.Clear();

        // Find all the audible AudioSources and add them to the list
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in allAudioSources)
        {
            if (audioSource.isPlaying && audioSource.volume > 0)
            {
                audibleAudioSources.Add(audioSource);
            }
        }

        foreach (var audioSource in audibleAudioSources)
        {
            if (audioSource.volume > overstimulationThreshold)
            {
                ApplyNoiseOverstimulation(audioSource);
            }
        }
    }

    void ApplyNoiseOverstimulation(AudioSource overstimulatedSource)
    {
        // Your noise overstimulation logic goes here
        // You can modify the environment, visuals, or perform any actions to indicate overstimulation.
        Debug.Log($"Noise overstimulation triggered for {overstimulatedSource.gameObject.name}!");
    }
}
