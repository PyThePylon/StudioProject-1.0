using UnityEngine;

public class SoundOnKeyPress : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;
    int pianotime = 0;
    float maxdistance;

    void Start()
    {
        // Get the AudioSource components
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the player presses the "E" key while colliding with the object
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNearObject(1))
        {
            // Play the sound
            if (soundToPlay != null)
            {
                //play first sound
                if (pianotime == 0)
                {
                    audioSource.clip = soundToPlay;
                    audioSource.Play();
                    pianotime = 1;
                }
                //play second sound
                if (pianotime == 1)
                {
                    audioSource.clip = soundToPlay;
                    audioSource.Play();
                    pianotime = 2;
                }
                //play full song
                if (pianotime == 2)
                {
                    audioSource.clip = soundToPlay;
                    audioSource.Play();
                    pianotime = 1;
                }
                else pianotime = 0;
            }

        }
    }
    bool IsPlayerNearObject(float maxDistance)
    {
        // Assuming the player's GameObject is tagged as "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the distance between the object and the player
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // Check if the distance is less than or equal to the maximum allowed distance
            return distance <= maxDistance;
        }

        // Return false if the player is not found or if something goes wrong
        return false;
    }
}
