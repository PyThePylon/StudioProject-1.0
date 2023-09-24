using System.Collections;
using UnityEngine;
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

    void Awake()
    {
        tmP.text = "";
        initialTextColor = tmP.color;

        npcAS = GetComponent<AudioSource>();
        if(npcAS != null)
        {
            npcAS.Play();

            npcAS.volume = 0.0f;
        }
        else
        {
            return;
        }

    }


    void Update()
    {

        float grabDist = Vector3.Distance(npcPosition.position, playerDist.position);

        if(grabDist <= maxDist)
        {
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
            playerRange = false;
        }

        if (!playerRange && tmP.color.a > minAlpha)
        {
            Color newTxtColor = tmP.color;
            newTxtColor.a -= Time.deltaTime * fadeSpeed;
            tmP.color = newTxtColor;

        } else if (playerRange && tmP.color.a < 1.0f)
        {
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
            emptyTxt += grabTxt[i];
            tmP.text = emptyTxt;
            yield return new WaitForSeconds(.25f);
        }

        yield return new WaitForSeconds(5f);

        tmP.text = "";
        tmP.color = initialTextColor;
        selectedDialogue = false;
    }


}
