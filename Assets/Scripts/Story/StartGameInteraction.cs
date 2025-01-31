using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameInteraction : EnvironmentInteractable
{
    public override void Start()
    {
        base.Start();
    }

    public override void Interact(PlayerState_Player interacter)
    {
        base.Interact(interacter);
        this.gameObject.SetActive(false);
    }
}
