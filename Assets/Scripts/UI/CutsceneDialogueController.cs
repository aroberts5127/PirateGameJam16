using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneDialogueController : MonoBehaviour
{
    [Header("Dialogue Rendering")]
    [SerializeField]
    private GameObject dialogueUIHolder;
    [SerializeField]
    private TextMeshProUGUI characterNameTMP;
    [SerializeField]
    private TextMeshProUGUI characterDialogueTMP;
    
    [Header("Image Rendering")]
    [SerializeField]
    private RawImage speaker1Renderer;
    [SerializeField]
    private RawImage speaker2Renderer;

    [Header("Other")]
    [SerializeField]
    private GameObject HowToCloseGO;
    [SerializeField]
    private PlayerDialogueScriptableObject playerRenderInfo_so;
    [SerializeField]
    private RenderFarm renderFarm;


    private float printSpeed = 30;
    private string currentDialogueText;
    private Coroutine printRoutine;
    public static event Action<DialogueData> newDialogueAction;
    public static event Action endDialogueAction;
    public static event Action dialogueActive;

    private DialogueData currentData;



    private void Start()
    {
        newDialogueAction += ProcessNewMonologue;
        //PlayerInput.dialogueTriggeredPause += ProcessNewMonologue;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueUIHolder.activeSelf)
            return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(printRoutine != null)
            {
                //Debug.Log("Skipping");
                SkipDialogue();
            }
            else
            {
                //Debug.Log("Accepting Input");
                progressDialogue();
            }
        }
    }

    private void ProcessNewMonologue(DialogueData data)
    {
        currentData = data;
        string char1Name;
        if (data.speaker1 == -1)
            char1Name = " ";
        else
         char1Name = playerRenderInfo_so.CharacterList[data.speaker1].name;
        if(dialogueUIHolder == null)
        {
            Debug.Log("WTF");
            return;
        }
        dialogueUIHolder.SetActive(true);
        characterNameTMP.text = char1Name;
        currentDialogueText = data.textBody;
        SetRenderTextureForCharacter(data.speaker1, speaker1Renderer);
        SetRenderTextureForCharacter(data.speaker2, speaker2Renderer);
        //Set Image for Speaker
        Debug.Log(data.eventId);
        Debug.Log(data.textBody);
        Debug.Log(currentDialogueText);
        printRoutine = StartCoroutine(printDialogueRoutine(currentDialogueText));
    }

    private IEnumerator printDialogueRoutine(string dialogue)
    {
        WaitForSeconds printWait = new WaitForSeconds(1/printSpeed);
        HowToCloseGO.SetActive(false);
        dialogueActive?.Invoke();
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

    private void SetRenderTextureForCharacter(int characterID, RawImage renderer)
    {

        if (characterID == -1)
        {
            renderer.gameObject.SetActive(false);
            return;
        }
        renderer.gameObject.SetActive(true);
        renderFarm.ActivateRenderFarmByID(characterID);
        renderer.texture = playerRenderInfo_so.CharacterList[characterID].renderTexture;
    }

    private void progressDialogue()
    {
        if (currentData.eventId == String.Empty)
        {
            //Debug.Log("Stuck in the void!");
            return;
        }
        if (currentData.nextEventId == string.Empty)
        {
            renderFarm.DeactivateAllRenderFarms();
            dialogueUIHolder.SetActive(false);
            currentData.eventId = String.Empty;
            endDialogueAction?.Invoke();
        }
        else
        {
            //Debug.Log("here");
            if (currentData.nextEventId != string.Empty)
                ProcessNewMonologue(DialogueDataProvider.Instance.RetrieveDialogueByEventID(currentData.nextEventId));
        }
    }

    public static void TriggerMonologueAction(DialogueData data)
    {
        newDialogueAction?.Invoke(data);
        dialogueActive?.Invoke();
    }

    public void OnDestroy()
    {
        newDialogueAction -= ProcessNewMonologue;
    }

}
