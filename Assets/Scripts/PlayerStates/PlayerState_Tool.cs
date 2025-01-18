using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Tool : PlayerState_Base, iDepossess
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

    void iDepossess.depossess()
    {
        Debug.Log("Deposessing");
    }
}
