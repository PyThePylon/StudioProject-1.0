using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : MonoBehaviour
{
    public float raycastDistance = 5f; // Adjust the distance of the raycast as needed

    private bool isLookingAtNPC = false;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Create a raycast from the player's position in the forward direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the raycast hits an object within the specified distance
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the hit object has the "NPC" tag
            if (hit.collider.CompareTag("NPC"))
            {
                // Do something when the raycast hits an object with the "NPC" tag
                Debug.Log("Raycast hit an NPC: " + hit.collider.gameObject.name);

                // Allow the player to press E and perform an action
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (isLookingAtNPC)
                    {
                        // Release the camera control and resume player movement
                        isLookingAtNPC = false;
                        // Add code here to allow the player to resume control of the camera

                        // Reset the camera to its original rotation
                        transform.rotation = originalRotation;

                        // Unlock the cursor
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    else if (Vector3.Distance(transform.position, hit.collider.gameObject.transform.position) <= raycastDistance)
                    {
                        // Look at the NPC
                        isLookingAtNPC = true;
                        // Make the player look at the NPC
                        transform.LookAt(hit.collider.gameObject.transform.position);

                        // Lock the cursor to the center of the screen
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                }
            }
            else
            {
                // Do something when the raycast hits an object without the "NPC" tag
                Debug.Log("Raycast hit a non-NPC object: " + hit.collider.gameObject.name);
                // Example: Perform a default action for non-NPC objects
            }
        }

        // Draw the raycast in the Scene view for visualization
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }
}
