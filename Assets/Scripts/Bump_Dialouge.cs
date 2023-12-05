using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bump_Dialouge : MonoBehaviour
{
    // Assuming you have a reference to TextMeshPro or UI Text to display the dialogue
    public TextMeshProUGUI dialogueText;

    // Assuming you have a reference to the canvas
    public Canvas dialogueCanvas;

    void Start()
    {
        // Optional: Hide the canvas initially
        HideDialogueCanvas();
    }

    void Update()
    {
        // Check for the "E" key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Hide the dialogue canvas when the player presses "E"
            HideDialogueCanvas();
        }
    }

    public void StartDialogue(string npcName)
    {
        string dialogue;

        // Switch statement to determine dialogue based on NPC name
        switch (npcName)
        {
            case "Older_Student":
                dialogue = "Hey Buck-O! Watch IT!";
                break;

            case "NPC2":
                dialogue = "Hey there! Be careful next time.";
                break;

            // Add more cases for other NPCs

            default:
                dialogue = "Watch where you're going!";
                break;
        }

        // Display the dialogue with NPC name
        dialogueText.text = dialogue;

        // Show the dialogue canvas
        ShowDialogueCanvas();

        // You might want to trigger other dialogue-related actions here
    }

    public void HideDialogueCanvas()
    {
        // Hide the dialogue canvas
        dialogueCanvas.gameObject.SetActive(false);
    }

    public void ShowDialogueCanvas()
    {
        // Show the dialogue canvas
        dialogueCanvas.gameObject.SetActive(true);
    }
}
