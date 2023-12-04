using System.Collections;
using TMPro;
using UnityEngine;

public class School_Scene_2 : MonoBehaviour
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
            "Mrs. Moore: Alright. Today we will be learning about the ABC’s, which is also known as the alphabet! We use the alphabet every single day, so it’s important to learn the letters of the alphabet.",
            "Mrs. Moore: So these are the letters of the alphabet. Let’s start with the letter ‘A’. ‘A’ is for apple and alligator! ‘B’ is for…",
            "Student 1: That new kid is kinda weird…",
            "Student 2: Yea, what’s wrong with him?",
            "Student 3: Weirdo…",
            "Student 4: I still have to use the bathroom.",
            "Jimmy: Leave him alone. You’re all just mean.",
            "Jimmy: Are you ok? I’m Jimmy, nice to meet you.",
            "Jimmy: You don’t talk much, huh? That’s okay. My sister is like that too. Do you want to be my friend?",
            "Jimmy: Cool! So, where did you-",
            "Mrs. Moore: Jimmy! Are you paying attention? Let’s go over the alphabet again. A is for…",
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}
