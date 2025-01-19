using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Player : PlayerState_Base
{
    private iInteractable interactableTarget;

    void Start()
    {
        PState = State.PLAYER;
        origPlayerObject = this.gameObject;
    }

    public override void PerformAction(PlayerStats stats)
    {
        if (interactableTarget == null)
        {
            Debug.Log("Nothing to Interact With");
            return;
        }
        interactableTarget.Interact(this);
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
