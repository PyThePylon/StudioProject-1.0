using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;


    void Start()
    {

        Debug.Log("Loading!");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertiInput = Input.GetAxis("Vertical");

        Vector3 movePlayer = new Vector3(horizInput, 0.0f, vertiInput);

        transform.Translate(movePlayer * moveSpeed * Time.deltaTime);


    }

}
