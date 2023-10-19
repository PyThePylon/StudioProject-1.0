using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbucusPieceMovement : MonoBehaviour
{
    public float hoverHeight = 0.2f;
    private bool isBeingDragged = false;
    private float distance;

    void OnMouseEnter()
    {
        transform.localScale += Vector3.one * 0.1f;
    }

    void OnMouseExit()
    {
        transform.localScale -= Vector3.one * 0.1f;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        isBeingDragged = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnMouseUp()
    {
        isBeingDragged = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (isBeingDragged)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(rayPoint.x, hoverHeight, transform.position.z);
        }
    }
}
