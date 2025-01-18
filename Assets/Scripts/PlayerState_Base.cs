using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State { PLAYER, TOOL, WEAPON}
public class PlayerState_Base : MonoBehaviour
{
    public State PState;
    protected GameObject origPlayerObject;

    public virtual void PerformAction()
    {
        Debug.Log("Base Interact Is Called");
    }
}
