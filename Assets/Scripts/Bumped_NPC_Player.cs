using UnityEngine;

public class Bumped_NPC_Player : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float rotationDistance = 5f;
    private bool isLocked = false;
    private Quaternion defaultRotation;

    void Start()
    {
        defaultRotation = transform.rotation;
    }

    void Update()
    {
        if (isLocked && Input.GetKeyDown(KeyCode.E))
        {
            UnlockCamera();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractableNPC") && !isLocked)
        {
            Debug.Log("Entered trigger zone of NPC");

            // Assuming you have a component on the NPC containing the NPC's name
            string npcName = other.name;

            // Access the Bump_Dialogue script attached to the player
            Bump_Dialouge bumpDialogue = GetComponent<Bump_Dialouge>();

            // Trigger the dialogue based on NPC name
            bumpDialogue.StartDialogue(npcName);

            // Lock the camera
            LockCamera(other.gameObject);
        }
    }

    private void LockCamera(GameObject targetNPC)
    {
        isLocked = true;

        // Calculate the height of the NPC to dynamically set the camera look-at position
        float npcHeight = targetNPC.GetComponent<Renderer>().bounds.size.y;

        // Set the camera to look at the top of the NPC
        transform.LookAt(targetNPC.transform.position + Vector3.up * npcHeight);
        Debug.Log("Camera locked onto NPC");
    }

    private void UnlockCamera()
    {
        isLocked = false;
        transform.rotation = defaultRotation;
        Debug.Log("Camera unlocked");
    }
}
