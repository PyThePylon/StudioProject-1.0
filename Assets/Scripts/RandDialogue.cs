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
    public AudioClip[] npcAC;
    [Range(-3, 3)]
    [SerializeField] float minP = 0.5f;
    [Range(-3, 3)]
    [SerializeField] float maxP = 2f;


    [Header("Text Movement")]
    public float verticalSpeed = 0.5f;
    public float verticalHeight = 0.1f;

    private float timeCounter = 0f;
    public float waveSpeed = 1.0f;
    public float waveHeight = 0.3f;
    public float maxWaveHeight = 0.5f; // Set your desired maximum wave height
    public float minWaveHeight = -0.5f;

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

        timeCounter += Time.deltaTime * waveSpeed;

    // Create a copy of the original vertices for manipulation
    Vector3[] vertices = tmP.textInfo.meshInfo[0].vertices;

    for (int i = 0; i < tmP.textInfo.characterCount; i++)
    {
        // Get the current character info
        TMP_CharacterInfo charInfo = tmP.textInfo.characterInfo[i];

        if (!charInfo.isVisible)
        {
            continue;
        }

        // Calculate the wave effect
        float yOffset = Mathf.Sin(timeCounter + i * 0.25f) * waveHeight * 0.05f;

        // Clamp the yOffset to keep it within the desired range
        yOffset = Mathf.Clamp(yOffset, minWaveHeight, maxWaveHeight);

        // Apply the wave effect to each character's vertices
        int vertexIndex = charInfo.vertexIndex;

        // Apply the wave effect to the bottom vertices of the character
        vertices[vertexIndex + 0] += new Vector3(0, yOffset, 0);
        vertices[vertexIndex + 1] += new Vector3(0, yOffset, 0);
        vertices[vertexIndex + 2] += new Vector3(0, yOffset, 0);
        vertices[vertexIndex + 3] += new Vector3(0, yOffset, 0);
    }

    // Update the altered vertices in the text mesh
    tmP.textInfo.meshInfo[0].mesh.vertices = vertices;
    tmP.UpdateGeometry(tmP.textInfo.meshInfo[0].mesh, 0);

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

            Vector3 textPosition = npcPosition.position + Vector3.up * 2.0f; // Adjust the '2.0f' value to position the text as desired
            tmP.transform.position = textPosition;

            npcAS.clip = npcAC[randClip];
            npcAS.pitch = Random.Range(minP, maxP);
            npcAS.Play();
            yield return new WaitForSeconds(npcAS.clip.length);
        }

        yield return new WaitForSeconds(5f);
        tmP.text = "";
        tmP.color = initialTextColor;
        tmP.transform.position = new Vector3(0, 0, 0);
        selectedDialogue = false;
    }


}
