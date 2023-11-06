using System.Collections;
using UnityEngine;
using TMPro;

public class CanvasTut : MonoBehaviour
{
    public int showInstrucOnce = 0;
    float maxDist = 5f;
    bool playerRange = false;
    public Transform abaPosition;
    public Transform playerPos;
    public Canvas[] instucCanvas;

    void Update()
    {
        float grabDist = Vector3.Distance(abaPosition.position, playerPos.position);

        if (grabDist <= maxDist)
        {
            playerRange = true;

            if (playerRange && showInstrucOnce <= 0)
            {
                instucCanvas[0].gameObject.SetActive(true);
            }
            else
            {
                if (playerRange && showInstrucOnce == 1)
                {
                    instucCanvas[1].gameObject.SetActive(true);
                }
                else
                {
                    if (playerRange)
                    {
                        instucCanvas[2].gameObject.SetActive(true);
                    }
                }
            }
        }
        else
        {
            instucCanvas[2].gameObject.SetActive(false);
            playerRange = false;
        }
    }
   


}
