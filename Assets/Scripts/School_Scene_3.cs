using System.Collections;
using TMPro;
using UnityEngine;

public class School_Scene_3 : MonoBehaviour
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
           "Jimmy: Come on, Arwin. Let’s go get lunch! I want pizza!",
           "Mrs. Moore: Arwin. Before you head out, I need to ask you for something. I’m missing some books. Do you think you could find them for me? Thank you, dear.",
           
        };
    }

    void Awake()
    {
        InitializeSentences();
    }
}
