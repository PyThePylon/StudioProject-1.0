using System.Collections;
using TMPro;
using UnityEngine;

public class Bed_Room_Convo_1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneFade sceneFade;

    public GameObject npc1;
    public GameObject npc2;

    // Reference to the Dialogue script
    public Dialogue dialogueScript;

    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            dialogueScript.PlayRandomDialogue();
        }
        yield return new WaitForSeconds(2f);

        if (index < sentences.Length - 1)
        {
            if (index == 3)
            {
                sceneFade.fadeIn = true;
                sceneFade.FadeIn();
            }
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            sceneFade.fadeOut = true;
            sceneFade.FadeOut();

            // Stop audio when dialogue is complete

            yield return new WaitForSeconds(2f);
            textDisplay.enabled = false;
            Destroy(npc1);
            Destroy(npc2);
        }
    }

    // Example sentences for the dialogue
    void InitializeSentences()
    {
        sentences = new string[]
        {
            "Good morning, Arwin! We’re going to see the doctor today.",
            "You’ve got an appointment at 11, so let’s get ready to head out the door! We don’t want to be late.",
            "John, do you think they’ll be able to finally give us an answer? We’ve been to so many doctors and specialists, it’s starting to feel hopeless.",
            "I sure hope so, Mary. I just don’t know what else to do for him.",
            "It’s okay, Arwin. We’re going to find help for you.",
            "Whenever you’re ready, walk out the door and we’ll head to the doctor’s office."
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}

