using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour, iInteractable
{
    [SerializeField]
    private string dialogueID;
    private DialogueData data;
    public void Interact()
    {
        CutsceneDialogueController.TriggerMonologueAction(data);
        //will need to figure out how to stop player from moving
    }

    public void Interact(PlayerState_Player interacter)
    {
        CutsceneDialogueController.TriggerMonologueAction(data);
        //Freeze Input for Player
        //interacter.StopMovementForPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueID != string.Empty)
            data = DialogueDataProvider.Instance.RetrieveDialogueByEventID(dialogueID);  
    }

}
