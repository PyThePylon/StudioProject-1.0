using System.Collections;
using TMPro;
using UnityEngine;

public class School_Scene : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneFade sceneFade; // Reference to the SceneFade script

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
            if (index == 10)
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
        }
    }

    // Example sentences for the dialogue
    void InitializeSentences()
    {
        sentences = new string[]
        {
            "Mrs. Moore: Good morning everyone!",
            "All students: Good morning, Mrs. Moore!",
            "Mrs. Moore: We’re gonna have lots of fun in class today! But first, I’d like to introduce you all to our newest student. This is Arwin Thompson, and he’ll be joining our kindergarten class. Everyone say hello to Arwin!",
            "Student 1: Hi, Arwin!",
            "Student 2: Hey there!",
            "Student 3: Who’s Arwin?",
            "Student 4: I have to use the bathroom.",
            "Student 5: Hello, Arwin!",
            "Mrs. Moore: Okay let’s settle down, everyone!",
            "Mrs. Moore: Go have a seat, Arwin. There’s a seat in the back just for you. When you’re ready, we’ll get started.",
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}
