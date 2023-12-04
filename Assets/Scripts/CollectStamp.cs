using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStamp : MonoBehaviour
{
    public GameObject collectStamp;
    public GameObject stamp;
    public GameObject stampSheet;
    bool canCollect = false;
    public AudioSource stampSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canCollect)
        {
            stamp.SetActive(!stamp.activeSelf);
            stampSheet.SetActive(true);
            collectStamp.SetActive(false);
            stampSound.Play();
            Object.Destroy(this.gameObject, 1);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        canCollect = true;
        collectStamp.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        collectStamp.SetActive(false);
        canCollect = false;
    }
    
}
