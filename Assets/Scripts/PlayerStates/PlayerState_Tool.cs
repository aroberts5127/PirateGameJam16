using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Tool : PlayerState_Base, iDepossess, iInteractable, iControllable
{
    // Start is called before the first frame update
    void Start()
    {
        PState = State.TOOL;
    }

    public override void PerformAction()
    {
        Debug.Log("Tool Interact Firing");
    }


    void iInteractable.Interact(PlayerState_Player interacter)
    {
        Debug.Log("Possessing Tool");
        //Need to Feedback and Take ownership of the PlayerInput Module;
    }

    void iDepossess.depossess()
    {
        Debug.Log("Deposessing");
    }

}
