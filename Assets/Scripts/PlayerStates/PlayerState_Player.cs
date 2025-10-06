using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Player : PlayerState_Base
{
    private iInteractable interactableTarget;
    public static event Action<bool, PlayerState_Base> PlayerInBody;
    [SerializeField]
    private Transform _followerTarget;

    void Start()
    {
        PState = State.PLAYER;
        origPlayerObject = this.gameObject;
        CutsceneDialogueController.endDialogueAction += ActivatePromptViaTextEnd;
    }


    public override void PerformAction(PlayerStats stats)
    {
        if (interactableTarget == null)
        {
            //Debug.Log("Nothing to Interact With");
            return;
        }
        interactableTarget.Interact(this);
        interactableTarget = null;
    }

    public void setInteractableTarget(iInteractable obj)
    {
        interactableTarget = obj;
    }

    public void resetInteractableTarget()
    {
        interactableTarget = null;
        InteractPromptListener.ActivatePromptAction(actionPrompts);
    }

    public void InvokePlayerInBody(bool inBody, PlayerState_Base ps)
    {
        Debug.Log("Here Invoking");
        PlayerInBody?.Invoke(inBody, ps);
    }

    public void StopMovementForPlayer()
    {
        this.GetComponentInChildren<PlayerInput>().SetInputsOff();
    }

    public void ForcePerformAction()
    {
        PerformAction(null);
    }

    public Transform GetFollowerTarget()
    {
        return _followerTarget;
    }

    private void ActivatePromptViaTextEnd()
    {
        InteractPromptListener.ActivatePromptAction(actionPrompts);
    }

}
