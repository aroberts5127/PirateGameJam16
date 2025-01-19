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

    public virtual void PerformAction()
    {
        Debug.Log("Base Interact Is Called");
    }

    public Transform GetMovementGO()
    {
        return movementGO;
    }
}
