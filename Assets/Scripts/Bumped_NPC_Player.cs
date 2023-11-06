using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumped_NPC_Player : MonoBehaviour
{
    public GameObject npc; // Reference to the NPC object
    public float rotationSpeed = 5f; // Speed of rotation
    public float rotationDistance = 5f; // Distance at which the rotation starts
    private bool isLocked = false; // Check if the camera is locked onto the NPC
    private Quaternion defaultRotation; // Store the default rotation of the player

    // Start is called before the first frame update
    void Start()
    {
        defaultRotation = transform.rotation; // Store the default rotation of the player
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the player and the NPC
        float distance = Vector3.Distance(transform.position, npc.transform.position);

        // If the player is within the specified distance, lock the camera onto the NPC
        if (distance < rotationDistance && !isLocked)
        {
            isLocked = true;
            // Set the camera to look at the top of the NPC
            transform.LookAt(npc.transform.position + Vector3.up * 8f); // Adjust the multiplier for the NPC's scaled dimensions
        }

        // If the camera is locked and the player presses the "E" key, unlock the camera
        if (isLocked && Input.GetKeyDown(KeyCode.E))
        {
            isLocked = false;
            npc.GetComponent<Bump_Dist>().ResetRotation(); // Call the method to reset the NPC rotation
            transform.rotation = defaultRotation; // Reset the player's rotation to the default rotation
        }
    }
}
