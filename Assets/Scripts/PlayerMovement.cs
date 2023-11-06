using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f; // Adjust the speed to your liking


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        string currScene = SceneManager.GetActiveScene().name;

        if (currScene != "ExamRoomScene")
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
        }
    }
}
