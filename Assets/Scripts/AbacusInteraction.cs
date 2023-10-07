using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusInteraction : MonoBehaviour
{
    float rSpeed = 30f;

    bool abaInteraction = false;
    //Vector3 lMPos;
    Vector3 origin;
    Quaternion originRotation;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        CanvasTut cT = GetComponent<CanvasTut>();
        bool moveCam = abaInteraction;

        if (Input.GetKeyDown(KeyCode.I))
        {

            abaInteraction = !abaInteraction;
            mainCamera.GetComponent<CamFollow>().enabled = moveCam;

            if (abaInteraction)
            {
                cT.instucCanvas[0].gameObject.SetActive(false);
                cT.showInstrucOnce += 1;
                Vector3 abaNewPos = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
                transform.position = abaNewPos;
            }
            else
            {
                cT.showInstrucOnce += 1;
                cT.instucCanvas[1].gameObject.SetActive(false);
                cT.instucCanvas[2].gameObject.SetActive(false);
                transform.position = origin;
                transform.rotation = originRotation;
                
            }
        }

        if(abaInteraction)
        {
            if (Input.GetMouseButton(0))
            {

                float rotX = Input.GetAxis("Mouse X");
                float rotY = Input.GetAxis("Mouse Y");

                // Rotate the object based on mouse movement
                transform.Rotate(Vector3.up, -rotX * rSpeed * Time.deltaTime);
                transform.Rotate(Vector3.forward, rotY * rSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        abaInteraction = true;
                    }
                }
            }
        }
    }
}
