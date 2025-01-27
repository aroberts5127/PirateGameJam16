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
        
    }

    public void Interact(PlayerState_Player interacter)
    {
        CutsceneDialogueController.TriggerMonologueAction(data);
        //Freeze Input for Player
        interacter.StopMovementForPlayer();
    }

    // Start is called before the first frame update
    void Start()
    { 
      data = DialogueDataProvider.Instance.RetrieveDialogueByEventID(dialogueID);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
