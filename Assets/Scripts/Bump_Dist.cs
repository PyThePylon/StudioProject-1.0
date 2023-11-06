using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump_Dist : MonoBehaviour
{
    private Quaternion originalRotation; // Store the original rotation of the NPC
    public Transform player; // Reference to the player object
    public float rotationSpeed = 5f; // Speed of rotation
    public float rotationDistance = 5f; // Distance at which the rotation starts

    // Start is called before the first frame update
    void Start()
    {
        // Store the original rotation of the NPC
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {

            // Calculate the distance between the NPC and the player
            float distance = Vector3.Distance(transform.position, player.position);

            // If the player is within the specified distance, rotate the NPC towards the player only on the Y-axis
            if (distance < rotationDistance)
            {
                Vector3 direction = player.position - transform.position;
                direction.y = 0f; // Lock the Y-component to 0 to ensure rotation only around the Y-axis
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    // Method to reset the rotation of the NPC to the original rotation
    public void ResetRotation()
    {
        transform.rotation = originalRotation; // Reset the rotation to the original rotation
    }
}
