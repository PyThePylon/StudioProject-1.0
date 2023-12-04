using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public AudioClip[] audioClips;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Make sure it is attached to the GameObject.");
        }
        else
        {
            // Load audio clips from the specified folder
            audioClips = Resources.LoadAll<AudioClip>("NPC Voices");

            if (audioClips.Length == 0)
            {
                Debug.LogError("No audio clips found in the 'SoundNPCVoices' folder. Make sure the folder and audio files are set up correctly.");
            }
        }
    }

    public void PlayRandomDialogue()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips available for dialogue.");
            return;
        }

        // Select a random audio clip
        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];

        // Set a random pitch (adjust the range as needed)
        audioSource.pitch = Random.Range(0.8f, 1.2f);

        // Play the selected audio clip
        audioSource.clip = randomClip;
        audioSource.Play();
    }
}
