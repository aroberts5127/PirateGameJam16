using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour, iInteractable
{

    public void Interact()
    {
        
    }

    public void Interact(PlayerState_Player interacter)
    {
        CutsceneDialogueController.TriggerDialogueAction("Protag", "I have interacted with this sign. It says nothing important");
        //Freeze Input for Player
        interacter.StopMovementForPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
