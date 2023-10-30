using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Quaternion originalRotation;
    public float moveSpeed = 5f; // Adjust the speed to your liking

    public GameObject npcCube;
    private bool isLookingAtNPC = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertiInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizInput, 0.0f, vertiInput);
        moveDirection = transform.TransformDirection(moveDirection); // Convert to world space

        // Normalize the movement vector to prevent faster diagonal movement
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

        // Use Rigidbody.MovePosition to move the character
        rb.MovePosition(transform.position + moveAmount);

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
            else if (Vector3.Distance(transform.position, npcCube.transform.position) < 2f)
            {
                // Look at the NPC
                isLookingAtNPC = true;
                // Make the player look at the NPC
                transform.LookAt(npcCube.transform.position);

                // Lock the cursor to the center of the screen
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
