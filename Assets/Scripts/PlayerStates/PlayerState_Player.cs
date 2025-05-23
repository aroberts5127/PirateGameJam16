using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Player : PlayerState_Base
{
    private iInteractable interactableTarget;
    public event Action<bool> PlayerInBody;
    [SerializeField]
    private Transform _followerTarget;

    public static PlayerState_Player Instance;

    void Start()
    {
        PState = State.PLAYER;
        origPlayerObject = this.gameObject;
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
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
    }

    public void InvokePlayerInBody(bool inBody)
    {
        PlayerInBody?.Invoke(inBody);
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

}
