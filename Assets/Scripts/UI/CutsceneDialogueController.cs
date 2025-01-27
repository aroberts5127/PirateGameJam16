using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneDialogueController : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueUIHolder;
    [SerializeField]
    private TextMeshProUGUI characterNameTMP;
    [SerializeField]
    private TextMeshProUGUI characterDialogueTMP;
    [SerializeField]
    private GameObject HowToCloseGO;
    private float printSpeed = 30;
    private string currentDialogueText;
    private Coroutine printRoutine;
    public static event Action<string, string> newDialogueAction;
    public static event Action endDialogueAction;



    private void Start()
    {
        newDialogueAction += ProcessNewMonologue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(printRoutine != null)
            {
                Debug.Log("Skipping");
                SkipDialogue();
            }
            else
            {
                endDialogue();
            }
        }
    }

    private void ProcessNewMonologue(string speaker, string dialogue)
    {
        dialogueUIHolder.SetActive(true);
        characterNameTMP.text = speaker;
        currentDialogueText = dialogue;
        //Set Image for Speaker
        printRoutine = StartCoroutine(printDialogueRoutine(dialogue));
    }

    private IEnumerator printDialogueRoutine(string dialogue)
    {
        WaitForSeconds printWait = new WaitForSeconds(1/printSpeed);
        HowToCloseGO.SetActive(false);
        string curText = "";
        foreach(char c in dialogue)
        {
            curText += c;
            if (c != ' ')
            {
                characterDialogueTMP.text = curText;
                yield return printWait;
            }
            else
            {
                characterDialogueTMP.text = curText;
                yield return new WaitForEndOfFrame();
            }
            
        }
        printRoutine = null;
        //Need to Handle Closing it now
        HowToCloseGO.SetActive(true);
    }

    private void SkipDialogue()
    {
        StopCoroutine(printRoutine);
        printRoutine = null;
        characterDialogueTMP.text = currentDialogueText;
        HowToCloseGO.SetActive(true);
    }

    private void endDialogue()
    {
        dialogueUIHolder.SetActive(false);
        endDialogueAction?.Invoke();
    }

    public static void TriggerMonologueAction(DialogueData data)
    {
        newDialogueAction?.Invoke(data.speaker1, data.textBody);
    }

}
