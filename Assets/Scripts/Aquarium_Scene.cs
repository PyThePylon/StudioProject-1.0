using System.Collections;
using TMPro;
using UnityEngine;

public class Aquarium_Scene : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneFade sceneFade;

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
        }
    }

    // Example sentences for the dialogue
    void InitializeSentences()
    {
        sentences = new string[]
        {
            "Mr. Green: Okay, everyone settle down. We’re here at the Georgia Aquarium, and since this is a field-trip, everyone needs to be on their best behavior.",
            "Jimmy: Arwin, I’m so excited! The aquarium is so cool I love fish. I have a goldfish, his name is-",
            "Mr. Green: Jimmy, are you listening? Anyways, there are plenty of wonderful fish here to see at the aquarium, but first I’d like to introduce you all to Ms. Amy. She’s going to be telling you guys a little more about the aquarium before you go exploring.",
            "Ms. Amy: Hello everyone! I am Ms. Amy, and I work here at the aquarium. There are lots of beautiful creatures that can be found in waters all across the world, including this aquarium! We have fish, turtles, and even sharks!",
            "Ms. Amy: You will all notice that you got a stamp card when you came in. As you kids are looking around, make sure to keep an eye out for our stamp machines! If you get all 6 stamps on your stamp card, you’ll win a prize at the end of the day!",
            "Mr. Green: Alright everyone, feel free to explore the aquarium and interact with the exhibits! Make sure to come find Ms. Amy when you find all 6 stamps!",
            "Jimmy: Oh boy! I hope they have a goldfish!",
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}
