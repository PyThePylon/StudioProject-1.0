using System.Collections;
using TMPro;
using UnityEngine;

public class WaitingRoomScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneFade sceneFade; // Reference to the SceneFade script

    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;

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
            if (index == 7)
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

            yield return new WaitForSeconds(2f);
            textDisplay.enabled = false;
            Destroy(npc1);
            Destroy(npc2);
            Destroy(npc3);
        }
    }

    // Example sentences for the dialogue
    void InitializeSentences()
    {
        sentences = new string[]
        {
            "Receptionist: “How may I help you?”",
            "Dad: “We’re here with Arwin Thompson. We have an 11am appointment with Dr. Fischer.”",
            "Dad: “Take Arwin and find a place to sit, I’ll be with you guys in just a minute.”",
            "Mom: “Everything is okay Arwin! We’re just seeing the doctor again. Here, play with this!”",
            "Dad: “The doctor should call him any minute now. How is he doing?”",
            "Mom: “Same as always, with these waiting rooms. I don’t think he likes being around so many people…”",
            "Dr. Fischer: “Arwin Thompson?”",
            "Dad: “Alright, time to go buddy. When you’re ready, let’s head into the exam room.”"
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}
