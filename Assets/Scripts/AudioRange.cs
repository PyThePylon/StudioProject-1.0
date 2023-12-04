using UnityEngine;
public class AudioRange : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public GameObject redAudioArea;  // Reference to the Red Audio_Area game object
    public GameObject blueAudioArea;  // Reference to the Blue Audio_Area game object
    public CanvasGroup redCanvasGroup;  // Reference to the red CanvasGroup component
    public CanvasGroup blueCanvasGroup;  // Reference to the blue CanvasGroup component
    public float maxAudioDistance = 10f;  // Maximum distance for audio volume adjustment
    public float fadeDuration = 1f;  // Duration for the fade effect

    private AudioSource redAudioSource;
    private AudioSource blueAudioSource;

    void Start()
    {
        // Assuming both Audio_Area game objects have AudioSource components
        redAudioSource = redAudioArea.GetComponent<AudioSource>();
        blueAudioSource = blueAudioArea.GetComponent<AudioSource>();

        if (redAudioSource == null || blueAudioSource == null)
        {
            Debug.LogError("AudioSource component not found on one or more Audio_Area game objects.");
        }

        if (redCanvasGroup == null || blueCanvasGroup == null)
        {
            Debug.LogError("CanvasGroup components not assigned.");
        }
    }

    void Update()
    {
        if (redAudioSource != null && blueAudioSource != null && player != null &&
            redAudioArea != null && blueAudioArea != null &&
            redCanvasGroup != null && blueCanvasGroup != null)
        {
            // Calculate the distance between the player and the Red Audio_Area
            float distanceToRedAudio = Vector3.Distance(player.position, redAudioArea.transform.position);

            // Calculate the normalized distance (0 to 1) based on the maxAudioDistance
            float normalizedDistanceToRedAudio = Mathf.Clamp01(distanceToRedAudio / maxAudioDistance);

            // Adjust the volume of the red audio based on the normalized distance
            redAudioSource.volume = 1f - normalizedDistanceToRedAudio;

            // Calculate the distance between the player and the Blue Audio_Area
            float distanceToBlueAudio = Vector3.Distance(player.position, blueAudioArea.transform.position);

            // Calculate the normalized distance (0 to 1) based on the maxAudioDistance
            float normalizedDistanceToBlueAudio = Mathf.Clamp01(distanceToBlueAudio / maxAudioDistance);

            // Adjust the volume of the blue audio based on the normalized distance
            blueAudioSource.volume = 1f - normalizedDistanceToBlueAudio;

            // Change the color of the canvas based on the tag
            FadeCanvas(redCanvasGroup, normalizedDistanceToBlueAudio);
            FadeCanvas(blueCanvasGroup, normalizedDistanceToRedAudio);
        }
    }

    private void FadeCanvas(CanvasGroup canvasGroup, float normalizedDistance)
    {
        if (canvasGroup != null)
        {
            // Fade the canvas image based on the normalized distance
            float targetAlpha = 1f - normalizedDistance;
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, Time.deltaTime / fadeDuration);
        }
    }
}
    
