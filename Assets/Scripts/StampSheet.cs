using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StampSheet : MonoBehaviour
{
    public GameObject stampSheetCanvas;
    public GameObject stampSheet;
    public GameObject pressEUI;
    public GameObject toggleUI;
    bool canCollect = false;
    public GameObject stampCollectors;
    void Update()
    {
        if (canCollect && Input.GetKeyDown(KeyCode.E))
        {
            stampSheetCanvas.SetActive(true);
            toggleUI.SetActive(true);
            pressEUI.SetActive(false);
            stampCollectors.SetActive(true);
            Object.Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        canCollect = true;
        pressEUI.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        pressEUI.SetActive(false);
        canCollect = false;
    }
}
