using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandDialogue : MonoBehaviour
{

    bool selectedDialogue = false;

    [Header("Dialogue List")]
    public GameObject[] listOfDialogues;

    [Header("EmptyTextMesh")]
    public TextMeshPro tmP;

    [Header("NPC position")]
    public Transform npcPosition;

    void Awake()
    {
        tmP.text = "";
    }


    void Update()
    {

        if(selectedDialogue != true)
        {
            transform.position = npcPosition.position + Vector3.up * 2.0f;
            selectedDialogue = true;
            StartCoroutine(randomDialogueGen());
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
        selectedDialogue = false;
    }
}
