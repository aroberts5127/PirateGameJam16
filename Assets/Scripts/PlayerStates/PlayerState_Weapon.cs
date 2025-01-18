using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Weapon : PlayerState_Base, iDepossess
{

    // Start is called before the first frame update
    void Start()
    {
        PState = State.WEAPON;
    }

    void iDepossess.depossess()
    {
        Debug.Log("Weapon Depossess Called");
    }
}
