using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandDialogue : MonoBehaviour
{

    [Header("Text parameters")]
    public float fadeSpeed = 1.2f;
    public float minAlpha = 0.0f;
    Color initialTextColor;

    [Header("maxDist")]
    float maxDist = 10f;

    [Header("Booleans")]
    bool selectedDialogue = false;
    bool playerRange = false;

    [Header("Dialogue List")]
    public GameObject[] listOfDialogues;

    [Header("PlayerDist")]
    public Transform playerDist;

    [Header("EmptyTextMesh")]
    public TextMeshPro tmP;

    [Header("NPC position")]
    public Transform npcPosition;

    [Header("NPC Audio")]
    public AudioSource npcAS;
    public AudioClip[] npcAC;
    [Range(-3, 3)]
    [SerializeField] float minP = 0.5f;
    [Range(-3, 3)]
    [SerializeField] float maxP = 2f;


    [Header("Text Movement")]
    public float verticalSpeed = 0.5f;
    public float verticalHeight = 0.1f;
    private Vector3 initialPosition;



    void Awake()
    {
        tmP.text = "";
        initialTextColor = tmP.color;
    }


    void Update()
    {

        float grabDist = Vector3.Distance(npcPosition.position, playerDist.position);

        if(grabDist <= maxDist)
        {
            Debug.Log("in range!");
            playerRange = true;
            if(!selectedDialogue)
            {
                transform.position = npcPosition.position + Vector3.up * 2.0f;
                selectedDialogue = true;
                StartCoroutine(randomDialogueGen());
            }
        }
        else
        {
            Debug.Log("Not in range!");
            playerRange = false;
        }
        
        
        if (!playerRange && tmP.color.a > minAlpha)
        {
            Debug.Log("fade!");
            Color newTxtColor = tmP.color;
            newTxtColor.a -= Time.deltaTime * fadeSpeed;
            tmP.color = newTxtColor;

        } else if (playerRange && tmP.color.a < 1.0f)
        {
            Debug.Log("Dont fade!");
            Color newTxtColor = tmP.color;
            newTxtColor.a += Time.deltaTime * fadeSpeed;
            tmP.color = newTxtColor;
        }

        if (npcAS != null)
        {
            float maxVol = 1.0f;
            float givenVol = Mathf.Clamp01(1.0f - (grabDist / maxDist)) * maxVol;
            npcAS.volume = givenVol;
        }

    }


    IEnumerator randomDialogueGen()
    {

        int randNum = Random.Range(0, listOfDialogues.Length);

        GameObject currDialogue = listOfDialogues[randNum];

        string grabTxt = currDialogue.GetComponentInChildren<TextMeshPro>().text;

        string emptyTxt = "";



        for(int i = 0; i < grabTxt.Length; i++)
        {

            int randClip = Random.Range(0, npcAC.Length);

            emptyTxt += grabTxt[i];
            tmP.text = emptyTxt;

            npcAS.clip = npcAC[randClip];
            npcAS.pitch = Random.Range(minP, maxP);
            npcAS.Play();
            yield return new WaitForSeconds(npcAS.clip.length);
        }

        yield return new WaitForSeconds(5f);
        tmP.text = "";
        tmP.color = initialTextColor;
        selectedDialogue = false;
    }


}
