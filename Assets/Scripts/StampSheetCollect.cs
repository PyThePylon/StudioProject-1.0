using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampSheetCollect : MonoBehaviour
{
    public GameObject stampSheetCanvas;
    public GameObject toggleUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            stampSheetCanvas.SetActive(!stampSheetCanvas.activeSelf);
            toggleUI.SetActive(false);
        }
    }
}
