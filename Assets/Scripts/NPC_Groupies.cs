using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Groupies : MonoBehaviour
{
    public float interactionRange = 3f; // Adjust the interaction range as needed
    public Canvas dialogueCanvas; // Reference to your dialogue canvas
    public TextMeshProUGUI dialogueText; // Reference to your TextMeshPro or UI Text component

    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithGroup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            // Show the interaction prompt when entering the trigger
            ShowInteractionPrompt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            // Hide the interaction prompt when exiting the trigger
            HideInteractionPrompt();
        }
    }

    private void ShowInteractionPrompt()
    {
        // Show the "E to Interact" prompt on the canvas
        dialogueText.text = "Press 'E' to Interact";
        dialogueCanvas.gameObject.SetActive(true);

        // Debug log for checking if ShowInteractionPrompt is executed
        Debug.Log("ShowInteractionPrompt executed");
    }

    private void HideInteractionPrompt()
    {
        // Hide the interaction prompt on the canvas
        dialogueCanvas.gameObject.SetActive(false);

        // Debug log for checking if HideInteractionPrompt is executed
        Debug.Log("HideInteractionPrompt executed");
    }

    private void TryInteractWithGroup()
    {
        // Assuming you have a component on the NPC containing the NPC's group
        string group = gameObject.name; // Use the name of the empty GameObject as the group name

        // Trigger the dialogue based on the NPC group
        TriggerGroupDialogue(group);
    }

    private void TriggerGroupDialogue(string group)
    {
        string dialogue;

        switch (group)
        {
            case "Group_1":
                // Dialogue for Group_1
                dialogue = "Group 1: Hello, we are the first group!";
                break;

            case "Group_2":
                // Dialogue for Group_2
                dialogue = "Group 2: Welcome to the second group!";
                break;

            // Add more cases for other groups

            default:
                // Default dialogue for unknown group
                dialogue = "Unknown group: Hello!";
                break;
        }

        // Display the dialogue on the canvas
        DisplayDialogue(dialogue);
    }

    private void DisplayDialogue(string dialogue)
    {
        // Display the dialogue on the canvas
        dialogueText.text = dialogue;

        // You might want to trigger other dialogue-related actions here
        Debug.Log(dialogue);
    }

}