using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { PLAYER, TOOL, WEAPON}
public class PlayerState_Base : MonoBehaviour
{
    public State PState;
    protected GameObject origPlayerObject;
    [SerializeField]
    protected Transform movementGO;
    public event Action<PlayerState_Base> performActionEvent;


    public virtual void PerformAction(PlayerStats stats)
    {
        //Debug.Log("Base Interact Is Called");
        performActionEvent?.Invoke(this);
    }

    public Transform GetMovementGO()
    {
        return movementGO;
    }

    public virtual void performActionsCompleted()
    {
        Debug.Log("All Actions for this object necessary are completed");
    }
}
