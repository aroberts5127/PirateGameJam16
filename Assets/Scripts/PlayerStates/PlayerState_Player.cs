using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Player : PlayerState_Base, iControllable
{
    private iInteractable interactableTarget;

    void Start()
    {
        PState = State.PLAYER;
        origPlayerObject = this.gameObject;
    }

    public override void PerformAction()
    {
        if (interactableTarget == null)
        {
            Debug.Log("Nothing to Interact With");
            return;
        }
        interactableTarget.Interact(this);
        //Assign new object's PlayerState_x.origPlayerObj with this.gameObject
    }

    public void setInteractableTarget(iInteractable obj)
    {
        interactableTarget = obj;
    }

    public void resetInteractableTarget()
    {
        interactableTarget = null;
    }

    

}
