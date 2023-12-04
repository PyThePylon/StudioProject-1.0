using System.Collections;
using TMPro;
using UnityEngine;

public class ExamRoomConvo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public SceneFade sceneFade;

    public bool moveNow = false;

    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;

    public Dialogue dialogueScript;

    void Awake()
    {
        InitializeSentences();
    }

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
            if (index == 11)
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

    void InitializeSentences()
    {
        sentences = new string[]
        {
            "Mom: 'So, Dr. Fischer, after running your tests, what can you tell us about our son? We’ve taken him to nearly every doctor and specialist in Atlanta and we just don’t know where else to turn.'",
            "Dr. Fischer: 'After reviewing his files and examining him closely, I believe I may know what is causing his seemingly strange behavior.'",
            "Dad: 'Really? What is it?'",
            "Dr. Fischer: 'Your son, Arwin, has ASD, meaning he is on the autism spectrum. ASD is a developmental disability, which has different effects on different people, which is why it’s classified as a spectrum. People with ASD develop at a different pace than others, which can cause differences in their behavior.'",
            "Dr. Fischer: 'In your son’s case, it seems as though his case is more severe, as it has resulted in lack of communication, as well as hypersensitivity, meaning he can become overstimulated very easily, which I think is causing his tantrums.'",
            "Mom: 'Autism..? I guess it makes sense now. At his age, he’s supposed to be talking already, but he hasn’t spoken a word. But what can we do for him, Dr. Fischer? Is there a cure for ASD?'",
            "Dr. Fischer: 'No, I’m afraid there is no known cure for ASD. However, there are things that you, as parents, can do for Arwin to help him grow and have a fulfilling life. There are plenty of people with ASD that grow up and go on to live perfectly normal, happy lives.'",
            "Dr. Fischer: 'It’s important to take note of his behavior, and pay attention to the kinds of things that may cause him to be overstimulated, like a loud television or a crowded group of people. It’s best to avoid these kinds of things to avoid a meltdown. Sometimes, the best thing to do when he’s overstimulated is take him to a safe place and give him his space.'",
            "Dr. Fischer: 'But the most important thing to remember is to treat Arwin with love and be very patient with him. Children with ASD respond best to positive reinforcement, so make sure to reward him for good behavior.'",
            "Mom: 'Thank you so much, Dr. Fischer. It’s been so hard on us, not being able to understand what’s happening with our son or how to help him. We’re going to do everything we can to give Arwin the best life possible.'",
            "Dr. Fischer: 'My pleasure, I’m glad I was able to help your family find the answers you needed. Call me if you ever need anything.'",
            "Mom: 'Well Arwin, since you did so well with the doctor today, let’s go to the store and pick out a new toy.'"
        };
    }
}
